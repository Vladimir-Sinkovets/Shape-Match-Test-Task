using Assets.Game.Scripts.Features.Figures;
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