using Assets.Game.Scripts.Core.Inputs;
using Assets.Game.Scripts.Features.CollectionPanels;
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
        private ICollectionPanel _collectionPanel;

        [Inject]
        public void Inject(IFiguresSpawner figuresSpawner,
            IFiguresPool figuresPool,
            IFigurePicker figurePicker,
            ICollectionPanel collectionPanel)
        {
            _figuresSpawner = figuresSpawner;
            _figuresPool = figuresPool;
            _figurePicker = figurePicker;
            _collectionPanel = collectionPanel;
        }

        private void Start()
        {
            _figuresPool.Init();

            _collectionPanel.Init();

            _figurePicker.Init();

            _figuresSpawner.Spawn(_figuresPool.Figures);

            _figurePicker.OnFigurePicked += _collectionPanel.Take;
        }

        private void OnEnable()
        {
            _figurePicker.OnFigurePicked -= _collectionPanel.Take;
        }
    }
}
