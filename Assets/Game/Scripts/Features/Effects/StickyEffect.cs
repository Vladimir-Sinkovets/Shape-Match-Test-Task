using Assets.Game.Scripts.Features.Figures;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Effects
{
    public class StickyEffect : IFigureEffect
    {
        private Figure _connectedFigure;
        private FixedJoint2D _joint;
        private Figure _figure;

        public void Init(Figure figure) => _figure = figure;

        public void HandleCollision(Figure collider)
        {
            if (_connectedFigure != null)
                return;

            if (_joint == null)
                _joint = _figure.AddComponent<FixedJoint2D>();

            _joint.connectedBody = collider.Rigidbody;

            _connectedFigure = collider;
        }

        public void DeletePhysics()
        {
            GameObject.Destroy(_joint);
        }
        public bool CanBePicked => true;
    }
}