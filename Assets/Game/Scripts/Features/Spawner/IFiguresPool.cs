using Assets.Game.Scripts.Features.Figures;
using System;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Features.Spawner
{
    public interface IFiguresPool
    {
        IEnumerable<Figure> Figures { get; }
        int DeletedFiguresCount { get; }

        event Action OnFiguresOut;
        event Action OnFigureDestroyed;

        void Init();
    }
}