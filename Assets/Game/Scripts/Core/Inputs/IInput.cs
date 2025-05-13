using System;
using UnityEngine;

namespace Assets.Game.Scripts.Core.Inputs
{
    public interface IInput
    {
        event Action<Vector2> OnTouched;
    }
}