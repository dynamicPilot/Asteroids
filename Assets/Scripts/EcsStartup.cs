using Leopotam.Ecs;
using UnityEngine;
using System.Demo;
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

namespace Client {
    sealed class EcsStartup : MonoBehaviour 
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;

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
            EcsSystems inputSystems = InputSystems();
            EcsSystems spawnerSystem = SpawnSystems();
            

            _systems

                // register your systems:
                .Add(inputSystems)
                .Add(spawnerSystem)


                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                .Inject(_staticData)
                .Inject(_sceneData)

                .Init ();

            EcsSystems coreSystems = CoreGameplaySystems();
            EcsSystems movableSystems = MovableSystems();
            EcsSystems teleportSystems = TeleportSystems();

            _fixedSystems
                
                .Add(teleportSystems)                
                .Add(movableSystems)
                .Add(coreSystems)
                .OneFrame<OnTriggerExit2DEvent>()               
                .OneFrame<OnCollisionEnter2DEvent>()               
                .Inject(_staticData)
                .Init();
        }

        private EcsSystems SpawnSystems()
        {
            return new EcsSystems(_world)
                .Add(new SpawnPlayer())
                .Add(new TeleportSpawner())
                .Add(new EnemySpawner())
                .Add(new SpawnSystem());
        }

        private EcsSystems InputSystems()
        {
            EcsSystems inputSystems = new EcsSystems(_world)
                .OneFrame<VertucalKeyDownTag>()
                .OneFrame<HorizontalKeyDownTag>()
                .Add(new KeyInputSystem())
                .Add(new AddRotationInputSystem())
                .Add(new AddForceInputSystem());
                
            return inputSystems;
        }

        private EcsSystems MovableSystems()
        {
            return new EcsSystems(_world)
                .Add(new UpdateAccelerationSystem())
                .Add(new GravitationSystem())
                .Add(new MoveSystem())
                .Add(new TeleportingSystem())
                .Add(new UpdateBodyPositionAndRotation());
        }

        private EcsSystems CoreGameplaySystems()
        {
            return new EcsSystems(_world)

                .OneFrame<OnEnemyCollisionEvent>()
                .Add(new EnemyCollisionCheckerSystem())

                .OneFrame<DeadEvent>()
                .Add(new DeadByEnemyCollisionSystem())
                .Add(new DeadCheckerGameplaySystem());
        }

        private EcsSystems TeleportSystems()
        {
            return new EcsSystems(_world)
                .Add(new TeleportTriggerCheckerSystem());
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