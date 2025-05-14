using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public class HeavyEffect : FigureEffect
    {
        public override void Init(Figure figure)
        {
            base.Init(figure);

            figure.Rigidbody.gravityScale *= 1.5f;
        }
    }
}