using Assets.Game.Scripts.Features.Spawner;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public interface ICollectionPanel
    {
        void Init();
        void Take(Figure figure);
    }
}