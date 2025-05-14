using Assets.Game.Scripts.Features.Figures;
using System;

namespace Assets.Game.Scripts.Features.Effects
{
    public class EmptyEffect : IFigureEffect
    {
        public void DeletePhysics() { }
        public void OnCollisionEnter(Figure figure, Figure collider) { }
        public void Start(Figure figure) { }
    }
}
