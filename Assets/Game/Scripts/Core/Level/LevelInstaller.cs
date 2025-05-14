using Assets.Game.Scripts.Features.CollectionPanels;
using Assets.Game.Scripts.Features.EndGamePanels;
using Assets.Game.Scripts.Features.FigurePickers;
using Assets.Game.Scripts.Features.Spawner;
using Assets.Game.Scripts.Features.UI;
using Assets.Game.Scripts.Shared.Constants;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private FiguresSpawner _figuresSpawner;
        [SerializeField] private FiguresPool _figuresPool;
        [SerializeField] private Camera _camera;
        [SerializeField] private CollectionPanel _collectionPanel;
        [SerializeField] private EndGamePanel _winPanel;
        [SerializeField] private EndGamePanel _losePanel;
        [SerializeField] private RefreshButtonEvents _refreshButtonEvents;

        public override void InstallBindings()
        {
            Container.BindInstance(_levelConfig);

            Container.Bind<IFiguresSpawner>().FromInstance(_figuresSpawner);

            Container.Bind<IFiguresPool>().FromInstance(_figuresPool);

            Container.BindInterfacesTo<Inputs.Input>()
                .AsSingle();

            Container.BindInterfacesTo<FigurePicker>()
                .AsSingle();

            Container.BindInstance(_camera);

            Container.Bind<ICollectionPanel>().FromInstance(_collectionPanel);

            Container.BindInstance(_winPanel)
                .WithId(DependencyInjectionIds.WinPanelId);

            Container.BindInstance(_losePanel)
                .WithId(DependencyInjectionIds.LosePanelId);

            Container.Bind<IRefreshButtonEvents>().FromInstance(_refreshButtonEvents);
        }
    }
}
