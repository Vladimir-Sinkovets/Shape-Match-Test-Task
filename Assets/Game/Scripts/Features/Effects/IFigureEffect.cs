using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public interface IFigureEffect
    {
        void DeletePhysics();
        void HandleCollision(Figure collider);
        void Init(Figure figure);
    }
}