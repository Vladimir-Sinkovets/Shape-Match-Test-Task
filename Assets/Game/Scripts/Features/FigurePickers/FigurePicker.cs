using Assets.Game.Scripts.Core.Inputs;
using Assets.Game.Scripts.Features.Figures;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.FigurePickers
{
    public class FigurePicker : IFigurePicker, IDisposable
    {
        private readonly IInput _input;

        public event Action<Figure> OnFigurePicked;

        public FigurePicker(IInput input)
        {
            _input = input;
        }

        public void Init()
        {
            _input.OnTouched += OnTouchedHandler;
        }

        private void OnTouchedHandler(Vector2 touchPosition)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            worldPosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent<Figure>(out var figure))
            {
                if (!figure.CanBePicked)
                    return;

                OnFigurePicked?.Invoke(figure);
            }
        }

        public void Dispose()
        {
            _input.OnTouched -= OnTouchedHandler;
        }
    }
}
