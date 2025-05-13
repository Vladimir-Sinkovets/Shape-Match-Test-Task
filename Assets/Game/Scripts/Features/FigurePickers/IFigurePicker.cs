using Assets.Game.Scripts.Features.Spawner;
using System;

namespace Assets.Game.Scripts.Features.FigurePickers
{
    public interface IFigurePicker : IDisposable
    {
        event Action<Figure> OnFigurePicked;

        void Init();
    }
}