using Assets.Game.Scripts.Features.CollectionPanels;
using Assets.Game.Scripts.Features.Figures;

namespace Assets.Game.Scripts.Features.Effects
{
    public abstract class FigureEffect
    {
        protected Figure Figure;

        public virtual void Init(Figure figure)
        {
            Figure = figure;
        }
        public virtual void DeletePhysics() { }
        public virtual void HandleCollision(Figure collider) { }
        public virtual void HandlePanelMatch(ICollectionPanelRemovable collectionPanel) { }

        public virtual void Clear() { }

        public virtual bool CanBePicked => true;
    }
}