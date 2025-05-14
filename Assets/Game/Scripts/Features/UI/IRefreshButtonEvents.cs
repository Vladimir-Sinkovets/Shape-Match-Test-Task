using System;

namespace Assets.Game.Scripts.Features.UI
{
    public interface IRefreshButtonEvents
    {
        event Action OnRefreshButtonClicked;
    }
}