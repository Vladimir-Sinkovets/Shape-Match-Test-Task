using Assets.Game.Scripts.Features.Figures;
using System;

namespace Assets.Game.Scripts.Features.FigurePickers
{
    public interface IFigurePicker : IDisposable
    {
        event Action<Figure> OnFigurePicked;

        void Init();
    }
}