using Assets.Game.Scripts.Core.Inputs;
using Assets.Game.Scripts.Features.Spawner;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelMain : MonoBehaviour
    {
        private IFiguresSpawner _figuresSpawner;
        private IFiguresPool _figuresPool;
        private IInput _input;

        [Inject]
        public void Inject(IFiguresSpawner figuresSpawner, IFiguresPool figuresPool, IInput input)
        {
            _figuresSpawner = figuresSpawner;
            _figuresPool = figuresPool;
            _input = input;
        }

        private void Start()
        {
            _figuresPool.Init();

            _figuresSpawner.Spawn(_figuresPool.Figures);
        }
    }
}
