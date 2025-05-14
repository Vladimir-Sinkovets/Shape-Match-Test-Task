using Assets.Game.Scripts.Features.Effects;
using Assets.Game.Scripts.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Figures
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _icon;
        [SerializeField] private SpriteRenderer _coloredBackground;
        [SerializeField] private SpriteRenderer _background;

        [SerializeField] private PolygonCollider2D _polygonCollider;
        [SerializeField] private Rigidbody2D _rigidbody;

        private FigureData _data = new();

        private FigureEffect _effect;

        public event Action<Figure> OnDestroyed;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<Figure>(out var collisionFigure))
                _effect.HandleCollision(collisionFigure);
        }

        public Sprite IconSprite { get => _icon.sprite; }
        public Color Color { get => _coloredBackground.color; }
        public Sprite BackgroundSprite { get => _background.sprite; }
        public Rigidbody2D Rigidbody { get => _rigidbody; }

        public FigureData Data { get => _data; }
        public FigureEffect Effect { get => _effect; }
        public bool CanBePicked { get => _effect.CanBePicked; }

        public void SetShape(ShapeType shapeType, Sprite sprite)
        {
            UpdateColliderShape(sprite);

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

        public void SetEffect(FigureEffect effect)
        {
            _effect = effect;

            _effect.Init(this);
        }

        public void DeletePhysics()
        {
            _effect.DeletePhysics();

            Destroy(_polygonCollider);
            Destroy(_rigidbody);
        }

        private void UpdateColliderShape(Sprite sprite)
        {
            _polygonCollider.pathCount = 0;

            var shapeCount = sprite.GetPhysicsShapeCount();

            for (int i = 0; i < shapeCount; i++)
            {
                var points = new List<Vector2>();

                sprite.GetPhysicsShape(i, points);

                _polygonCollider.SetPath(i, points);
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}
