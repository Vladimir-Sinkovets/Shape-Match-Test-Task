using Assets.Game.Scripts.Shared.Enums;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Spawner
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _icon;
        [SerializeField] private SpriteRenderer _coloredBackground;
        [SerializeField] private SpriteRenderer _background;

        private FigureData _data = new();

        public event Action<Figure> OnDestroyed;

        public Sprite IconSprite { get => _icon.sprite; }
        public Color Color { get => _coloredBackground.color; }
        public Sprite BackgroundSprite { get => _background.sprite; }

        public FigureData Data { get => _data; }

        public void SetShape(ShapeType shapeType, Sprite sprite)
        {
            _background.sprite = sprite;
            _coloredBackground.sprite = sprite;

            _data.ShapeType = shapeType;
        }

        public void SetIcon(IconType iconType, Sprite sprite)
        {
            _icon.sprite = sprite;

            _data.IconType = iconType;
        }

        public void SetColor(ColorType colorType, Color color)
        {
            _coloredBackground.color = color;

            _data.ColorType = colorType;
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        public void DeletePhysics()
        {
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}
