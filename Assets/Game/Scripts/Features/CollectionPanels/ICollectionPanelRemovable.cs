namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public interface ICollectionPanelRemovable
    {
        void RemoveLast();
        int CurrentIndex { get; }
    }
}