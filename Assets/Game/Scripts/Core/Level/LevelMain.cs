using Assets.Game.Scripts.Core.Inputs;
using Assets.Game.Scripts.Features.FigurePickers;
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
        private IFigurePicker _figurePicker;

        [Inject]
        public void Inject(IFiguresSpawner figuresSpawner, IFiguresPool figuresPool, IFigurePicker figurePicker)
        {
            _figuresSpawner = figuresSpawner;
            _figuresPool = figuresPool;
            _figurePicker = figurePicker;
        }

        private void Start()
        {
            _figuresPool.Init();

            _figurePicker.Init();

            _figuresSpawner.Spawn(_figuresPool.Figures);
        }
    }
}
