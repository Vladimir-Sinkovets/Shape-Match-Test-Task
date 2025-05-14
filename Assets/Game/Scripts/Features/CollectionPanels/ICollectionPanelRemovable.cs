namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public interface ICollectionPanelRemovable
    {
        void Remove(int index);
        int CurrentIndex { get; }
    }
}