using Assets.Game.Scripts.Shared.Enums;
using Assets.Game.Scripts.Shared.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Features.Spawner
{
    public class FiguresSpawner : MonoBehaviour, IFiguresSpawner
    {
        [SerializeField] private float _timeBetweenSpawns = 0.1f;
        [Space]
        [SerializeField] private Transform _spawnPointFrom;
        [SerializeField] private Transform _spawnPointTo;

        private Vector2 _lastSpawnPosition;

        private LevelConfig _levelConfig;

        [Inject]
        public void Inject(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        public void Spawn(IEnumerable<Figure> figures)
        {
            StartCoroutine(SpawnFiguresCoroutine(figures));
        }

        private IEnumerator SpawnFiguresCoroutine(IEnumerable<Figure> figures)
        {
            DisableFigures(figures);

            var combinations = GenerateCombinations().Shuffle().ToArray();

            SetUpFigures(figures, combinations);

            yield return SpawnFigures(figures);
        }

        private static void DisableFigures(IEnumerable<Figure> figures)
        {
            foreach (var figure in figures)
            {
                figure.gameObject.SetActive(false);
            }
        }

        private IEnumerator SpawnFigures(IEnumerable<Figure> figures)
        {
            _lastSpawnPosition = _spawnPointFrom.position;

            foreach (var figure in figures)
            {
                figure.transform.position = GetNextRandomPosition();

                figure.gameObject.SetActive(true);

                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }

        private Vector2 GetNextRandomPosition()
        {
            var randomPosition = new Vector2(
                Random.Range(_spawnPointFrom.position.x, _spawnPointTo.position.x),
                Random.Range(_spawnPointFrom.position.y, _spawnPointTo.position.y));

            if (Vector2.Distance(randomPosition, _lastSpawnPosition) <= 0.5f)
            {
                var minX = _spawnPointFrom.position.x;
                var maxX = _spawnPointTo.position.x;
                var minY = _spawnPointFrom.position.y;
                var maxY = _spawnPointTo.position.y;

                var xOffsetDirection = (maxX - _lastSpawnPosition.x) > (_lastSpawnPosition.x - minX) ? 1 : -1;
                var newX = Mathf.Clamp(_lastSpawnPosition.x + xOffsetDirection * 0.5f, minX, maxX);

                var yOffsetDirection = (maxY - _lastSpawnPosition.y) > (_lastSpawnPosition.y - minY) ? 1 : -1;
                var newY = Mathf.Clamp(_lastSpawnPosition.y + yOffsetDirection * 0.5f, minY, maxY);

                randomPosition = new Vector2(newX, newY);
            }

            _lastSpawnPosition = randomPosition;

            return randomPosition;
        }

        private static void SetUpFigures(
            IEnumerable<Figure> figures,
            (SpriteConfig<ShapeType> Shape, SpriteConfig<IconType> Icon, ColorConfig Color)[] combinations)
        {
            var i = 0;
            foreach (var figure in figures)
            {
                var combination = combinations[i % combinations.Length];
                i++;

                figure.SetShape(combination.Shape.Type, combination.Shape.Sprite);
                figure.SetIcon(combination.Icon.Type, combination.Icon.Sprite);
                figure.SetColor(combination.Color.ColorType, combination.Color.Color);

            }
        }

        private IEnumerable<(SpriteConfig<ShapeType> Shape, SpriteConfig<IconType> Icon, ColorConfig Color)> GenerateCombinations()
        {
            foreach (var shape in _levelConfig.ShapeConfigs)
                foreach (var icon in _levelConfig.IconConfigs)
                    foreach (var color in _levelConfig.ColorConfigs)
                        yield return (shape, icon, color);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(_spawnPointFrom.position, _spawnPointTo.position);
        }
    }
}
