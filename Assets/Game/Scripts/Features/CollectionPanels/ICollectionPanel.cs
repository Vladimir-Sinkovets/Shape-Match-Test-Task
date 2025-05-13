using Assets.Game.Scripts.Features.Spawner;
using System;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public interface ICollectionPanel
    {
        event Action OnPanelOverloaded;
        void Init();
        void Take(Figure figure);
    }
}