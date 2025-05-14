using Assets.Game.Scripts.Features.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Features.Spawner
{
    public class FiguresPool : MonoBehaviour, IFiguresPool
    {
        [SerializeField] private Figure _figurePrefab;
        [Space]
        [SerializeField] private Transform _continer;

        public event Action OnFiguresOut;
        public event Action OnFigureDestroyed;

        private LevelConfig _levelConfig;
        private List<Figure> _figures;
        private int _deletedFigures;

        public IEnumerable<Figure> Figures { get => _figures; }

        public int DeletedFigures => _deletedFigures;

        public void Init()
        {
            _figures = CreateFigures().ToList();
        }

        [Inject]
        public void Inject(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        private IEnumerable<Figure> CreateFigures()
        {
            var count = _levelConfig.NumberOfDuplicates *
                _levelConfig.ShapeConfigs.Count *
                _levelConfig.ColorConfigs.Count *
                _levelConfig.IconConfigs.Count;

            for (int i = 0; i < count; i++)
            {
                var figure = Instantiate(_figurePrefab, Vector3.zero, Quaternion.identity, _continer);
                figure.gameObject.SetActive(false);

                figure.OnDestroyed += OnFigureDestroyedHandler;

                yield return figure;
            }
        }

        private void OnFigureDestroyedHandler(Figure figure)
        {
            _figures.Remove(figure);

            _deletedFigures++;

            OnFigureDestroyed?.Invoke();

            if (!_figures.Any())
            {
                OnFiguresOut?.Invoke();
            }
        }
    }
}
