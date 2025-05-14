using Assets.Game.Scripts.Features.Figures;
using System;

namespace Assets.Game.Scripts.Features.Effects
{
    public class HeavyEffect : IFigureEffect
    {
        public void DeletePhysics() { }
        public void HandleCollision(Figure collider) { }
        public void Init(Figure figure) => figure.Rigidbody.gravityScale *= 1.5f;
        public bool CanBePicked => true;
    }
}