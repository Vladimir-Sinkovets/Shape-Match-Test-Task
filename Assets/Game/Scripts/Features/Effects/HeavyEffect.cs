using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public class HeavyEffect : IFigureEffect
    {
        public void Start(Figure figure)
        {
            figure.Rigidbody.gravityScale *= 1.5f;
        }
    }
}