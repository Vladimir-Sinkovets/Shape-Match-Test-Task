using System;

namespace Assets.Game.Scripts.Features.Spawner
{
    public interface IRefreshButtonEvents
    {
        event Action OnRefreshButtonClicked;
    }
}