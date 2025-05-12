using Assets.Game.Scripts.Shared.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Spawner
{
    [CreateAssetMenu(fileName = "Level_config", menuName = "Level config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<IconConfig> _iconConfigs;
        [SerializeField] private List<ColorConfig> _colorConfigs;
        [SerializeField] private List<ShapeConfig> _shapeConfigs;

        public List<IconConfig> IconConfigs { get => _iconConfigs; }
        public List<ColorConfig> ColorConfigs { get => _colorConfigs; }
        public List<ShapeConfig> ShapeConfigs { get => _shapeConfigs; }
    }

    [Serializable]
    public class IconConfig
    {
        public Sprite Sprite;
        public IconType IconType;
    }

    [Serializable]
    public class ColorConfig
    {
        public Color Color;
        public ColorType ColorType;
    }

    [Serializable]
    public class ShapeConfig
    {
        public Sprite Sprite;
        public ShapeType ShapeType;
    }

}