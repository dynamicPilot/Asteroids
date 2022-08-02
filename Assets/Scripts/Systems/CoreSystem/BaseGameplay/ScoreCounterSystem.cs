using Components.GameStates.GameplayEvents;
using Components.Objects.Tags;
using Leopotam.Ecs;
using Services;
using UnityComponents.Common;

namespace Systems.CoreSystems.BaseGameplay
{
    public class ScoreCounterSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private ScoreService _score;
        private EcsWorld _world = null;
		private EcsFilter<EnemyTag, DestroyObject> _scoreFilter = null;
		private EcsFilter<DeadEvent> _finalScoreFilter = null;
		public void Run()
		{
			if (_scoreFilter.IsEmpty() && _finalScoreFilter.IsEmpty())
				return;

			foreach (int index in _scoreFilter)
			{
				EnemyTag enemyScore = _scoreFilter.Get1(index);
				_score.AddScore(enemyScore.Score);
				_sceneData.GameUIScript.SetScore(_score.Score, false);
			}

			if (_finalScoreFilter.IsEmpty())
				return;

			foreach (int index in _finalScoreFilter)
			{
				_sceneData.GameUIScript.SetScore(_score.Score, true);
			}
		}
	}
}
