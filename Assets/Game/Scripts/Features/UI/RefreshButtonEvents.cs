﻿using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.UI
{
    public class RefreshButtonEvents : MonoBehaviour, IRefreshButtonEvents
    {
        public event Action OnRefreshButtonClicked;

        public void Refresh() => OnRefreshButtonClicked?.Invoke();
    }
}
