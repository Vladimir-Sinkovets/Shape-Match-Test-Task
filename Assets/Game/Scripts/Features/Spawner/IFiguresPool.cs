using Assets.Game.Scripts.Features.Figures;
using System;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Features.Spawner
{
    public interface IFiguresPool
    {
        IEnumerable<Figure> Figures { get; }

        event Action OnFiguresOut;

        void Init();
    }
}