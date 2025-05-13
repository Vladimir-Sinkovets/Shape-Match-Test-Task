using Assets.Game.Scripts.Features.CollectionPanels;
using Assets.Game.Scripts.Features.EndGamePanels;
using Assets.Game.Scripts.Features.FigurePickers;
using Assets.Game.Scripts.Features.Spawner;
using Assets.Game.Scripts.Shared.Constants;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Core.Level
{
    public class LevelMain : MonoBehaviour
    {
        [Inject] private IFiguresSpawner _figuresSpawner;
        [Inject] private IFiguresPool _figuresPool;
        [Inject] private IFigurePicker _figurePicker;
        [Inject] private ICollectionPanel _collectionPanel;
        [Inject(Id = DependencyInjectionIds.WinPanelId)] private EndGamePanel _winPanel;
        [Inject(Id = DependencyInjectionIds.LosePanelId)] private EndGamePanel _losePanel;
        [Inject] private IRefreshButtonEvents _refreshButtonEvents;

        private void Start()
        {
            _figuresPool.Init();

            _collectionPanel.Init();

            _figurePicker.Init();

            _figuresSpawner.Spawn(_figuresPool.Figures);

            _figurePicker.OnFigurePicked += _collectionPanel.Take;

            _collectionPanel.OnPanelOverloaded += Lose;

            _figuresPool.OnFiguresOut += Win;

            _refreshButtonEvents.OnRefreshButtonClicked += Respawn;
        }

        private void Lose() => _losePanel.Show();
        private void Win() => _winPanel.Show();
        private void Respawn() => _figuresSpawner.Spawn(_figuresPool.Figures);

        private void OnDisable()
        {
            _figurePicker.OnFigurePicked -= _collectionPanel.Take;

            _collectionPanel.OnPanelOverloaded -= Lose;

            _figuresPool.OnFiguresOut -= Win;

            _refreshButtonEvents.OnRefreshButtonClicked -= Respawn;
        }
    }
}
