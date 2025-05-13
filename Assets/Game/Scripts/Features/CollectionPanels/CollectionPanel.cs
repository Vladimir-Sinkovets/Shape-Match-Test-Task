using Assets.Game.Scripts.Features.Spawner;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public class CollectionPanel : MonoBehaviour, ICollectionPanel
    {
        [SerializeField] private RectTransform _panel;
        [SerializeField] private float _movingTime;

        private List<RectTransform> _uiFigures;

        public void Init()
        {
            _uiFigures = new List<RectTransform>();

            foreach (RectTransform child in _panel)
            {
                _uiFigures.Add(child);
            }
        }

        public void Take(Figure figure)
        {
            figure.DeletePhysics();

            var destination = Camera.main.ScreenToWorldPoint(_uiFigures.First().position);

            destination.z = figure.transform.position.z;

            figure.transform.DOMove(destination, _movingTime)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    Debug.Log("Done");

                    // Set panel figure

                    Destroy(figure.gameObject);
                });
        }
    }
}
