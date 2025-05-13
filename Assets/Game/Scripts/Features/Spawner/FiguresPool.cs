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

        private LevelConfig _levelConfig;
        private List<Figure> _figures;

        public IEnumerable<Figure> Figures { get => _figures; }

        public void Init()
        {
            _figures = SpawnFigures().ToList();
        }

        [Inject]
        public void Inject(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        private IEnumerable<Figure> SpawnFigures()
        {
            for (int i = 0; i < _levelConfig.NumberOfDuplicates; i++)
            {
                foreach (var shape in _levelConfig.ShapeConfigs)
                {
                    foreach (var icon in _levelConfig.IconConfigs)
                    {
                        foreach (var color in _levelConfig.ColorConfigs)
                        {
                            var figure = Instantiate(_figurePrefab, Vector3.zero, Quaternion.identity, _continer);

                            figure.SetShape(shape.Type, shape.Sprite);
                            figure.SetIcon(icon.Type, icon.Sprite);
                            figure.SetColor(color.ColorType, color.Color);

                            figure.gameObject.SetActive(false);

                            figure.OnDestroyed += OnFigureDestroyedHandler;

                            yield return figure;
                        }
                    }
                }
            }
        }

        private void OnFigureDestroyedHandler(Figure figure) => _figures.Remove(figure);
    }
}
