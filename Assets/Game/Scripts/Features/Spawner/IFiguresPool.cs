using System.Collections.Generic;

namespace Assets.Game.Scripts.Features.Spawner
{
    public interface IFiguresPool
    {
        IEnumerable<Figure> Figures { get; }
        void Init();
    }
}