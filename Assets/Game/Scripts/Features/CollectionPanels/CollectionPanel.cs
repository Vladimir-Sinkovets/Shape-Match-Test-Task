using Assets.Game.Scripts.Features.Effects;
using Assets.Game.Scripts.Features.Figures;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public class CollectionPanel : MonoBehaviour, ICollectionPanel, ICollectionPanelRemovable
    {
        private const int FigureCountForMatch = 3;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private float _movingTime;

        public event Action OnPanelOverloaded;

        private FigureUI[] _uiFigures;
        private FigureData[] _data;
        private FigureEffect[] _effects;

        private int _currentIndex;
        private bool _isBlocked;

        public int CurrentIndex => _currentIndex;

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
            _effects = new FigureEffect[uiFigures.Count];
        }

        public void Take(Figure figure)
        {
            if (_isBlocked || _currentIndex >= _uiFigures.Length)
                return;

            _isBlocked = true;

            var uiFigure = _uiFigures[_currentIndex];
            _data[_currentIndex] = figure.Data;
            _effects[_currentIndex] = figure.Effect;

            _currentIndex++;

            var destination = Camera.main.ScreenToWorldPoint(uiFigure.transform.position);
            destination.z = figure.transform.position.z;

            figure.DeletePhysics();

            figure.transform.DOMove(destination, _movingTime)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    _isBlocked = false;

                    uiFigure.ShowFigure(figure.IconSprite, figure.Color, figure.BackgroundSprite);

                    Destroy(figure.gameObject);

                    if (HasMatch(out var index))
                    {
                        RemoveLastFigures(FigureCountForMatch);

                        ApplyEffects(index);
                    }

                    if (_currentIndex >= _uiFigures.Length)
                    {
                        OnPanelOverloaded?.Invoke();

                        return;
                    }
                });
        }

        public void RemoveLast()
        {
            _data[_currentIndex - 1] = null;

            _uiFigures[_currentIndex - 1].HideFigure();

            _currentIndex = _currentIndex - 1;
        }

        private void ApplyEffects(int index)
        {
            for (int i = index; i < index + FigureCountForMatch; i++)
            {
                _effects[i].HandlePanelMatch(this);
            }
        }

        private void RemoveLastFigures(int count)
        {
            for (int i = 0; i < count; i++)
                RemoveLast();
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

                if (sameIconsCount == FigureCountForMatch ||
                    sameShapesCount == FigureCountForMatch ||
                    sameColorsCount == FigureCountForMatch)
                {
                    index = i - FigureCountForMatch + 1;

                    return true;
                }
            }

            return false;
        }
    }
}
