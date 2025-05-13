using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Spawner
{
    public class FiguresSpawner : MonoBehaviour, IFiguresSpawner
    {
        [SerializeField] private float _timeBetweenSpawns = 0.1f;
        [Space]
        [SerializeField] private Transform _spawnPointFrom;
        [SerializeField] private Transform _spawnPointTo;

        public void Spawn(IEnumerable<Figure> figures)
        {
            StartCoroutine(SpawnFiguresCoroutine(figures));
        }

        private IEnumerator SpawnFiguresCoroutine(IEnumerable<Figure> figures)
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(_spawnPointFrom.position, _spawnPointTo.position);
        }
    }
}
