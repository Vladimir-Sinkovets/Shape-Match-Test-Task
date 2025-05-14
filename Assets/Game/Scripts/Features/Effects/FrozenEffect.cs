using Assets.Game.Scripts.Features.Figures;
using Assets.Game.Scripts.Features.Spawner;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Effects
{
    public class FrozenEffect : FigureEffect
    {
        private IFiguresPool _figuresPool;
        private readonly FrozenEffectConfig _effectConfig;
        private bool _isFrozen;

        private int _quantityForUnfreeze;
        private SpriteRenderer _ice;

        public override bool CanBePicked => !_isFrozen;

        public FrozenEffect(IFiguresPool figuresPool, FrozenEffectConfig effectConfig)
        {
            _figuresPool = figuresPool;
            _effectConfig = effectConfig;
            _isFrozen = true;
        }

        public override void Init(Figure figure)
        {
            base.Init(figure);

            _figuresPool.OnFigureDestroyed += OnFigureDestroyedHandler;

            _quantityForUnfreeze = _effectConfig.QuantityForUnfreeze;

            _ice = GameObject.Instantiate(_effectConfig.IceSprite, figure.transform);
        }

        private void OnFigureDestroyedHandler()
        {
            if (!_isFrozen)
                return;

            _figuresPool.OnFigureDestroyed -= OnFigureDestroyedHandler;

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