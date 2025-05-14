using Assets.Game.Scripts.Features.CollectionPanels;

namespace Assets.Game.Scripts.Features.Effects
{
    public class ExplosiveEffect : FigureEffect
    {
        public override void HandlePanelMatch(ICollectionPanelRemovable collectionPanel)
        {
            if (collectionPanel.CurrentIndex > 0)
                collectionPanel.RemoveLast();
        }
    }
}
