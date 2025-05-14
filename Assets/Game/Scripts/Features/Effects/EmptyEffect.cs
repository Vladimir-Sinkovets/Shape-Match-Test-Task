using Assets.Game.Scripts.Features.Figures;
using System;

namespace Assets.Game.Scripts.Features.Effects
{
    public class EmptyEffect : IFigureEffect
    {
        public void DeletePhysics() { }
        public void HandleCollision(Figure collider) { }
        public void Init(Figure figure) { }
        public bool CanBePicked => true;
    }
}
