using Leopotam.Ecs;
using UnityEngine;
using System.InputSystems;
using Components.Common.Input;
using Systems.Spawners;
using UnityComponents.Common;
using Systems.MoveSystems;
using Systems.InputSystems;
using Components.Core;
using Systems.CoreSystems.BaseGameplay;
using Components.GameStates.GameplayEvents;
using Components.PhysicsEvents;
using Systems.CoreSystems.Teleport;
using Systems.CoreSystems.Shooting;
using Systems;
using Systems.Destroyers;
using Leopotam.Ecs.Ui.Systems;
using Systems.UISystems;
using Services;

namespace Client {
    sealed class EcsStartup : MonoBehaviour 
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;
        [SerializeField] EcsUiEmitter _uiEmitter;

        private ScoreService _scoreService;

        EcsWorld _world;
        EcsSystems _systems;
        EcsSystems _fixedSystems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _fixedSystems = new EcsSystems(_world);
            

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedSystems);
#endif
            InitializedServices();


            InitializeUpdateSystems();
            InitializeFixedSystems();
        }

        private void InitializeUpdateSystems()
        {
            EcsSystems inputSystems = InputSystems();
            EcsSystems spawnerSystem = SpawnSystems();
            EcsSystems weaponSystems = WeaponSystems();
            EcsSystems uiSystems = UISystems();

            _systems
                
                .Add(new UpdateTimersSystem())
                .Add(uiSystems)
                .Add(weaponSystems)
                .Add(inputSystems)
                .Add(new ChangeWeaponShootsSystem())
                .Add(spawnerSystem)

                .Inject(_staticData)
                .Inject(_sceneData)
                .InjectUi(_uiEmitter)
                .Inject(_scoreService)
                .Init();

        }

        private void InitializeFixedSystems()
        {
            EcsSystems coreSystems = CoreGameplaySystems();
            EcsSystems scoreSystems = ScoreSystems();
            EcsSystems followPlayerSystems = FollowPlayerSystems();
            EcsSystems movableSystems = MovableSystems();
            EcsSystems teleportSystems = TeleportSystems();
            EcsSystems destroySystems = DestroySystems();

            _fixedSystems

                .Add(teleportSystems)
                .Add(movableSystems)
                .Add(followPlayerSystems)
                .Add(new UpdateBodyPositionAndRotation())
                .Add(new PlayerMovingInfoSystem())
                .Add(coreSystems)
                .Add(scoreSystems)
                .Add(destroySystems)
                .OneFrame<OnTriggerExit2DEvent>()
                .OneFrame<OnCollisionEnter2DEvent>()

                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(_scoreService)
                .Init();
        }

        private void InitializedServices()
        {
            _scoreService = new ScoreService();
        }

        private EcsSystems SpawnSystems()
        {
            return new EcsSystems(_world)
                .Add(new SpawnPlayer())
                .Add(new PlayerWeaponSpawner())
                .Add(new TeleportSpawner())
                .Add(new EnemySpawner())
                .Add(new BulletSpawner())
                .Add(new SpawnSystem());
        }

        private EcsSystems DestroySystems()
        {
            return new EcsSystems(_world)
                .Add(new DestroySystem());
        }

        private EcsSystems InputSystems()
        {
            EcsSystems inputSystems = new EcsSystems(_world)
                .OneFrame<VertucalKeyDownTag>()
                .OneFrame<HorizontalKeyDownTag>()
                .OneFrame<FirstWeaponFireKeyDownTag>()
                .Add(new KeyInputSystem())
                .Add(new ShootingInputSystem())
                .Add(new AddRotationInputSystem())
                .Add(new AddForceInputSystem())
                .Add(new WeaponShootCheckSystem());


            return inputSystems;
        }

        private EcsSystems FollowPlayerSystems()
        {
            return new EcsSystems(_world)
                .Add(new FollowPlayerAddPlayerPositionSystem())
                .Add(new FollowPlayerAddForceSystem());
        }

        private EcsSystems MovableSystems()
        {
            return new EcsSystems(_world)
                .Add(new UpdateAccelerationSystem())
                .Add(new GravitationSystem())
                .Add(new MoveSystem())
                .Add(new TeleportingSystem());
                
        }

        private EcsSystems CoreGameplaySystems()
        {
            return new EcsSystems(_world)

                .Add(new BulletCollisionCheckerSystem())

                .OneFrame<OnEnemyCollisionEvent>()
                .Add(new EnemyCollisionCheckerSystem())

                .OneFrame<DeadEvent>()
                .Add(new DeadByEnemyCollisionSystem())
                .Add(new DeadCheckerGameplaySystem());
                
        }

        private EcsSystems ScoreSystems()
        {
            return new EcsSystems(_world)
                .Add(new ScoreCounterSystem());
        }

        private EcsSystems WeaponSystems()
        {
            return new EcsSystems(_world)
                .Add(new CheckBulletTimersSystem())
                .Add(new CheckWeaponRecoverySystem());
        }

        private EcsSystems TeleportSystems()
        {
            return new EcsSystems(_world)
                .Add(new TeleportTriggerCheckerSystem());
        }

        private EcsSystems UISystems()
        {
            return new EcsSystems(_world)
                .Add(new UIGameProgressSystem());
        }

        void Update () {
            _systems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedSystems?.Run();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;

                _fixedSystems.Destroy();
                _fixedSystems = null;

                _world.Destroy ();
                _world = null;
            }
        }
    }
}