using Assets.Game.Scripts.Features.Spawner;
using Assets.Game.Scripts.Shared.Enums;

namespace Assets.Game.Scripts.Features.Effects
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IFiguresPool _figuresPool;
        private readonly LevelConfig _levelConfig;

        public EffectFactory(IFiguresPool figuresPool, LevelConfig levelConfig)
        {
            _figuresPool = figuresPool;
            _levelConfig = levelConfig;
        }

        public IFigureEffect Get(EffectType type)
        {
            return type switch
            {
                EffectType.None => new EmptyEffect(),
                EffectType.Frozen => new FrozenEffect(_figuresPool, _levelConfig.FrozenEffectConfig),
                EffectType.Sticky => new StickyEffect(),
                EffectType.Heavy => new HeavyEffect(),
                EffectType.Explosive => new EmptyEffect(),
                _ => new EmptyEffect(),
            };
        }
    }
}
