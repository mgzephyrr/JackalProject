using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Figures;
using UnityEngine;

namespace Figures.FigurePirate
{
    public class PirateMovement : IMovement
    {
        private Transform _transform;
        private Vector3 _position;
        public PirateMovement(Vector3 position, Transform transform)
        {
            _position = position;
            _transform = transform;
        }

        public void Move()
        {
            _transform.position = _position;
        }
    }
}

