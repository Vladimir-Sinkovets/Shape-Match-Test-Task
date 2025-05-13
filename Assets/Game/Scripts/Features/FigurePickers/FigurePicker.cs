using Assets.Game.Scripts.Core.Inputs;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.FigurePickers
{
    public class FigurePicker : IFigurePicker, IDisposable
    {
        private readonly IInput _input;
        private readonly Camera _camera;

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
            Debug.Log(touchPosition);

            Vector3 worldPosition = _camera.ScreenToWorldPoint(touchPosition);
            worldPosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Clicked: " + hit.collider.gameObject.name);
            }
        }

        public void Dispose()
        {
            _input.OnTouched -= OnTouchedHandler;
        }
    }
}
