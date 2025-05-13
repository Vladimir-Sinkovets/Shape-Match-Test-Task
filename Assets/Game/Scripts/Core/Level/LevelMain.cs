using Assets.Game.Scripts.Features.Spawner;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelMain : MonoBehaviour
    {
        private IFiguresSpawner _figuresSpawner;
        private IFiguresPool _figuresPool;

        [Inject]
        public void Inject(IFiguresSpawner figuresSpawner, IFiguresPool figuresPool)
        {
            _figuresSpawner = figuresSpawner;
            _figuresPool = figuresPool;
        }

        private void Start()
        {
            _figuresPool.Init();

            _figuresSpawner.Spawn(_figuresPool.Figures);
        }
    }
}
