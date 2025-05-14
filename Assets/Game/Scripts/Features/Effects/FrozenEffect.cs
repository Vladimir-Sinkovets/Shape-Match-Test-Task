using Assets.Game.Scripts.Features.Figures;
using Assets.Game.Scripts.Features.Spawner;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Features.Effects
{
    public class FrozenEffect : IFigureEffect
    {
        private IFiguresPool _figuresPool;
        private readonly FrozenEffectConfig _effectConfig;
        private bool _isFrozen;

        private int _quantityForUnfreeze;
        private SpriteRenderer _ice;

        public bool CanBePicked => !_isFrozen;

        public FrozenEffect(IFiguresPool figuresPool, FrozenEffectConfig effectConfig)
        {
            _figuresPool = figuresPool;
            _effectConfig = effectConfig;
            _isFrozen = true;
        }

        public void Init(Figure figure)
        {
            _figuresPool.OnFigureDestroyed += OnFigureDestroyedHandler;

            _quantityForUnfreeze = _effectConfig.QuantityForUnfreeze;

            _ice = GameObject.Instantiate(_effectConfig.IceSprite, figure.transform);
        }

        public void DeletePhysics() { }

        public void HandleCollision(Figure collider) { }

        private void OnFigureDestroyedHandler()
        {
            if (!_isFrozen)
                return;

            _quantityForUnfreeze--;

            if (_quantityForUnfreeze <= 0)
                Unfreeze();
        }

        private void Unfreeze()
        {
            GameObject.Destroy(_ice.gameObject);

            _isFrozen = false;
        }
    }
}