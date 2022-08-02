using Components.GameStates;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;

namespace Systems.UISystems
{
    public class UIGameProgressSystem : IEcsRunSystem
    {
		private const string _startGameButton = "StartGameButton";
		private const string _newGameButton = "NewGameButton";
		private EcsFilter<EcsUiClickEvent> _filter = null;
		private EcsFilter<GameProgress> _filterGameProgress = null;

		public void Run()
		{
			foreach (int index in _filter)
			{
				EcsUiClickEvent click = _filter.Get1(index);
				if (click.WidgetName.Equals(_startGameButton))
				{
					ref GameProgress gameProgress = ref _filterGameProgress.Get1(0);
					gameProgress.IsPause = false;
				}
				else if (click.WidgetName.Equals(_newGameButton))
                {
					ref GameProgress gameProgress = ref _filterGameProgress.Get1(0);
					gameProgress.IsPause = true;
				}
			}
		}
	}
}
