using Assets.Game.Scripts.Shared.Enums;

namespace Assets.Game.Scripts.Features.Effects
{
    public interface IEffectFactory
    {
        FigureEffect Get(EffectType type);
    }
}