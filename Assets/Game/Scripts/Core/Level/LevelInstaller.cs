using Assets.Game.Scripts.Features.Spawner;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private FiguresSpawner _figuresSpawner;
        [SerializeField] private FiguresPool _figuresPool;

        public override void InstallBindings()
        {
            Container.BindInstance(_levelConfig);

            Container.Bind<IFiguresSpawner>().FromInstance(_figuresSpawner);

            Container.Bind<IFiguresPool>().FromInstance(_figuresPool);
        }
    }
}
