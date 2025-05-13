using Assets.Game.Scripts.Shared.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Spawner
{
    [CreateAssetMenu(fileName = "Level_config", menuName = "Level config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _numberOfDuplicates;
        [SerializeField] private List<SpriteConfig<IconType>> _iconConfigs;
        [SerializeField] private List<ColorConfig> _colorConfigs;
        [SerializeField] private List<SpriteConfig<ShapeType>> _shapeConfigs;

        public List<SpriteConfig<IconType>> IconConfigs { get => _iconConfigs; }
        public List<ColorConfig> ColorConfigs { get => _colorConfigs; }
        public List<SpriteConfig<ShapeType>> ShapeConfigs { get => _shapeConfigs; }
        public int NumberOfDuplicates { get => _numberOfDuplicates; }
    }

    [Serializable]
    public class SpriteConfig<T> where T : Enum
    {
        public Sprite Sprite;
        public T Type;
    }

    [Serializable]
    public class ColorConfig
    {
        public Color Color;
        public ColorType ColorType;
    }
}