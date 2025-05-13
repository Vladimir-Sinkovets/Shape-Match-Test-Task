using Assets.Game.Scripts.Features.Spawner;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelMain : MonoBehaviour
    {
        private IFiguresSpawner _figuresSpawner;

        [Inject]
        public void Inject(IFiguresSpawner figuresSpawner)
        {
            _figuresSpawner = figuresSpawner;
        }

        private void Start()
        {
            _figuresSpawner.Spawn(1);
        }
    }
}
