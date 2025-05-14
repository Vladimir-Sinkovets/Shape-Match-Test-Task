using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public interface IFigureEffect
    {
        bool CanBePicked { get; }

        void DeletePhysics();
        void HandleCollision(Figure collider);
        void Init(Figure figure);
    }
}