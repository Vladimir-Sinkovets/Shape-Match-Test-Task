using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public interface IFigureEffect
    {
        void DeletePhysics();
        void OnCollisionEnter(Figure figure, Figure collider);
        void Start(Figure figure);
    }
}