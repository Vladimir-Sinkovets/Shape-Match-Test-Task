using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public class HeavyEffect : FigureEffect
    {
        private float _originalGravityScale;

        public override void Init(Figure figure)
        {
            base.Init(figure);

            _originalGravityScale = Figure.Rigidbody.gravityScale;

            Figure.Rigidbody.gravityScale = _originalGravityScale * 1.5f;
        }

        public override void Clear()
        {
            base.Clear();

            Figure.Rigidbody.gravityScale = _originalGravityScale;
        }
    }
}