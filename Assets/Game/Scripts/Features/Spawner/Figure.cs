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

        private ShapeType _shapeType;
        private ColorType _colorType;
        private IconType _iconType;

        public event Action<Figure> OnDestroyed;

        public ShapeType ShapeType { get => _shapeType; }
        public ColorType ColorType { get => _colorType; }
        public IconType IconType { get => _iconType; }

        public void SetShape(ShapeType shapeType, Sprite sprite)
        {
            _background.sprite = sprite;
            _coloredBackground.sprite = sprite;

            _shapeType = shapeType;
        }

        public void SetIcon(IconType iconType, Sprite sprite)
        {
            _icon.sprite = sprite;

            _iconType = iconType;
        }

        public void SetColor(ColorType colorType, Color color)
        {
            _coloredBackground.color = color;

            _colorType = colorType;
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
