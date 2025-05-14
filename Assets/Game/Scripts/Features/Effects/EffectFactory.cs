using Assets.Game.Scripts.Shared.Enums;

namespace Assets.Game.Scripts.Features.Effects
{
    public class EffectFactory : IEffectFactory
    {
        public IFigureEffect Get(EffectType type)
        {
            return type switch
            {
                EffectType.None => new EmptyEffect(),
                EffectType.Frozen => new FrozenEffect(),
                EffectType.Sticky => new StickyEffect(),
                EffectType.Heavy => new HeavyEffect(),
                EffectType.Explosive => new EmptyEffect(),
                _ => new EmptyEffect(),
            };
        }
    }
}
