using Assets.Game.Scripts.Features.Figures;
using Assets.Game.Scripts.Features.Spawner;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Effects
{
    public class FrozenEffect : FigureEffect
    {
        private IFiguresPool _figuresPool;
        private readonly FrozenEffectConfig _effectConfig;
        private bool _isFrozen;

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


            if (_effectConfig.QuantityForUnfreeze <= _figuresPool.DeletedFigures)
                Unfreeze();
            else
                _ice = GameObject.Instantiate(_effectConfig.IceSprite, figure.transform);
        }

        public override void Clear()
        {
            base.Clear();

            Unfreeze();
        }

        private void OnFigureDestroyedHandler()
        {
            if (!_isFrozen)
                return;

            if (_effectConfig.QuantityForUnfreeze <= _figuresPool.DeletedFigures)
                Unfreeze();
        }

        private void Unfreeze()
        {
            _figuresPool.OnFigureDestroyed -= OnFigureDestroyedHandler;

            if (_ice != null && !_ice.IsDestroyed())
                GameObject.Destroy(_ice.gameObject);

            _isFrozen = false;
        }
    }
}