using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Figures
{
    internal class Movement: IMovement
    {
        private readonly Transform _transform;
        private readonly UnityEngine.Vector3 _position;

        public Movement(Transform transform, UnityEngine.Vector3 position)
        {
            _transform = transform;
            _position = position;
        }

        public void Move()
        {
            _transform.position = _position;
        }
    }
}
