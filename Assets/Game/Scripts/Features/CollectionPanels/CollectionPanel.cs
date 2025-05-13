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

        private List<FigureUI> _uiFigures;

        public void Init()
        {
            _uiFigures = new List<FigureUI>();

            foreach (RectTransform child in _panel)
            {
                if (child.TryGetComponent<FigureUI>(out var figureUI))
                    _uiFigures.Add(figureUI);
            }
        }

        public void Take(Figure figure)
        {
            figure.DeletePhysics();

            var uiFigure = _uiFigures.First();

            var destination = Camera.main.ScreenToWorldPoint(uiFigure.transform.position);

            destination.z = figure.transform.position.z;

            figure.transform.DOMove(destination, _movingTime)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    Debug.Log("Done");

                    uiFigure.ShowFigure(figure.IconSprite, figure.Color, figure.BackgroundSprite);

                    Destroy(figure.gameObject);
                });
        }
    }
}
