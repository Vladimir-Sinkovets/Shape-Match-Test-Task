using Assets.Game.Scripts.Core.Inputs;
using Assets.Game.Scripts.Features.Figures;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.FigurePickers
{
    public class FigurePicker : IFigurePicker, IDisposable
    {
        private readonly IInput _input;
        private readonly Camera _camera;

        public event Action<Figure> OnFigurePicked;

        public FigurePicker(IInput input, Camera camera)
        {
            _input = input;
            _camera = camera;
        }

        public void Init()
        {
            _input.OnTouched += OnTouchedHandler;
        }

        private void OnTouchedHandler(Vector2 touchPosition)
        {
            Vector3 worldPosition = _camera.ScreenToWorldPoint(touchPosition);
            worldPosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent<Figure>(out var figure))
            {
                OnFigurePicked?.Invoke(figure);
            }
        }

        public void Dispose()
        {
            _input.OnTouched -= OnTouchedHandler;
        }
    }
}
