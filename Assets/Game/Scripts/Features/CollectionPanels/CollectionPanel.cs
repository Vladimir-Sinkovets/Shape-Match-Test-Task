using Assets.Game.Scripts.Features.Spawner;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public class CollectionPanel : MonoBehaviour, ICollectionPanel
    {
        [SerializeField] private RectTransform _panel;

        private List<RectTransform> _uiFigures;

        private void Start()
        {
            foreach (RectTransform child in _panel)
            {
                _uiFigures.Add(child);
            }
        }

        public void Take(Figure figure)
        {
            
        }
    }
}
