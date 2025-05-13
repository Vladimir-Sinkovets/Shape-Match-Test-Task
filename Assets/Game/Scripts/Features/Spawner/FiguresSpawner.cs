using Assets.Game.Scripts.Shared.Enums;
using Assets.Game.Scripts.Shared.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
            foreach (var figure in figures)
            {
                figure.transform.position = new Vector2(
                    Random.Range(_spawnPointFrom.position.x, _spawnPointTo.position.x),
                    Random.Range(_spawnPointFrom.position.y, _spawnPointTo.position.y));

                figure.gameObject.SetActive(true);

                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
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
