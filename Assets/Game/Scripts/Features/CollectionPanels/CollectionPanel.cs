using Assets.Game.Scripts.Features.Spawner;
using Assets.Game.Scripts.Shared.Enums;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public class CollectionPanel : MonoBehaviour, ICollectionPanel
    {
        [SerializeField] private RectTransform _panel;
        [SerializeField] private float _movingTime;

        public event Action OnPanelOverloaded;

        private FigureUI[] _uiFigures;
        private FigureData[] _data;

        private int _currentIndex;
        private bool _isBlocked;

        public void Init()
        {
            _currentIndex = 0;

            var uiFigures = new List<FigureUI>();

            foreach (RectTransform child in _panel)
            {
                if (child.TryGetComponent<FigureUI>(out var figureUI))
                    uiFigures.Add(figureUI);
            }

            _uiFigures = uiFigures.ToArray();

            _data = new FigureData[uiFigures.Count];
        }

        public void Take(Figure figure) // to do: split method
        {
            if (_isBlocked)
                return;

            _isBlocked = true;

            var uiFigure = _uiFigures[_currentIndex];
            _data[_currentIndex] = figure.Data;

            _currentIndex++;

            var destination = Camera.main.ScreenToWorldPoint(uiFigure.transform.position); // to do: fix
            destination.z = figure.transform.position.z;

            figure.DeletePhysics(); // to do: fix

            figure.transform.DOMove(destination, _movingTime)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    _isBlocked = false;

                    uiFigure.ShowFigure(figure.IconSprite, figure.Color, figure.BackgroundSprite);

                    Destroy(figure.gameObject);

                    if (HasMatch(out var index))
                    {
                        for (int i = index; i < index + 3; i++)
                        {
                            _data[i] = null;
                            _uiFigures[i].HideFigure();

                            _currentIndex = index;
                        }
                    }

                    if (_currentIndex >= _uiFigures.Length)
                    {
                        OnPanelOverloaded?.Invoke();

                        return;
                    }
                });
        }

        private bool HasMatch(out int index)
        {
            index = 0;

            if (_data[0] == null)
                return false;

            var sameIconsCount = 1;
            var sameShapesCount = 1;
            var sameColorsCount = 1;

            var iconType = _data[0].IconType;
            var shapeType = _data[0].ShapeType;
            var colorType = _data[0].ColorType;

            for (int i = 1; i < _data.Length; i++)
            {
                if (_data[i] == null)
                    break;

                sameIconsCount = iconType == _data[i].IconType ? sameIconsCount + 1 : 1;
                sameShapesCount = shapeType == _data[i].ShapeType ? sameShapesCount + 1 : 1;
                sameColorsCount = colorType == _data[i].ColorType ? sameColorsCount + 1 : 1;

                iconType = _data[i].IconType;
                shapeType = _data[i].ShapeType;
                colorType = _data[i].ColorType;

                if (sameIconsCount == 3 || sameShapesCount == 3 || sameColorsCount == 3)
                {
                    index = i - 2;

                    return true;
                }
            }

            return false;
        }
    }
}
