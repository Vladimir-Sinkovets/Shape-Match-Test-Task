using Assets.Game.Scripts.Features.CollectionPanels;

namespace Assets.Game.Scripts.Features.Effects
{
    public class ExplosiveEffect : FigureEffect
    {
        public override void HandlePanelMatch(int index, ICollectionPanelRemovable collectionPanel)
        {
            if (index > 0)
                collectionPanel.Remove(index - 1);
        }
    }
}
