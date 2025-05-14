using Assets.Game.Scripts.Features.Figures;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Features.Spawner
{
    public interface IFiguresSpawner
    {
        void Spawn(IEnumerable<Figure> figures);
    }
}