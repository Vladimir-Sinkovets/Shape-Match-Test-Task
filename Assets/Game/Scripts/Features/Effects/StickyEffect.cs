using Assets.Game.Scripts.Features.CollectionPanels;
using Assets.Game.Scripts.Features.Figures;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Game.Scripts.Features.Effects
{
    public class StickyEffect : FigureEffect
    {
        private Figure _connectedFigure;
        private FixedJoint2D _joint;

        public override void HandleCollision(Figure collider)
        {
            base.HandleCollision(collider);

            if (_connectedFigure != null)
                return;

            if (_joint == null)
                _joint = Figure.AddComponent<FixedJoint2D>();

            _joint.connectedBody = collider.Rigidbody;

            _connectedFigure = collider;
        }

        public override void DeletePhysics()
        {
            base.DeletePhysics();

            GameObject.Destroy(_joint);
        }
    }
}