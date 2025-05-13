using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Features.Spawner
{
    public class FiguresSpawner : MonoBehaviour, IFiguresSpawner
    {
        [SerializeField] private Figure _figurePrefab;
        [Space]
        [SerializeField] private Transform _continer;
        [SerializeField] private Transform _spawnPointFrom;
        [SerializeField] private Transform _spawnPointTo;
        [SerializeField] private float _timeBetweenSpawns = 0.1f;

        private LevelConfig _levelConfig;
        private IEnumerable<Figure> _figures;

        [Inject]
        public void Inject(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        public void Spawn(int count)
        {
            _figures = SpawnFigures(count);

            StartCoroutine(SetUpFigures(_figures));
        }

        public void ReSetUpFigures()
        {
            StartCoroutine(SetUpFigures(_figures));
        }

        private IEnumerator SetUpFigures(IEnumerable<Figure> figures)
        {
            foreach (var figure in figures)
            {
                figure.transform.position = new Vector2(
                    Random.Range(_spawnPointFrom.position.x, _spawnPointTo.position.x),
                    Random.Range(_spawnPointFrom.position.y, _spawnPointTo.position.y));

                figure.gameObject.SetActive(true);

                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }

        private IEnumerable<Figure> SpawnFigures(int count)
        {
            for (int i = 0; i < count; i++)
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

                            yield return figure;
                        }
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(_spawnPointFrom.position, _spawnPointTo.position);
        }
    }
}
