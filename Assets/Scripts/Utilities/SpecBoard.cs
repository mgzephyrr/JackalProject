using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class SpecBoard : MonoBehaviour
    {
        public float SizeCellZ => SizeZ / 8;
        public float SizeCellX => SizeX / 8;
        public float SizeX => Vector3.Distance(_leftUp, _leftBottom);
        public float SizeZ => Vector3.Distance(_rightUp, _leftBottom);

        private Vector3 _leftUp;
        private Vector3 _rightUp;
        private Vector3 _leftBottom;
        private Vector3 _rightBottom;
        private Renderer _renderer;
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            Bounds bounds = _renderer.bounds;
            print(bounds);
            _leftUp = bounds.ClosestPoint(new Vector3(Mathf.Infinity, 0, Mathf.Infinity));
            _rightUp = bounds.ClosestPoint(new Vector3(Mathf.Infinity, 0, -Mathf.Infinity));
            _leftBottom = bounds.ClosestPoint(new Vector3(-Mathf.Infinity, 0, Mathf.Infinity));
            _rightBottom = bounds.ClosestPoint(new Vector3(-Mathf.Infinity, 0, -Mathf.Infinity));
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = UnityEngine.Color.red;
            Gizmos.DrawSphere(_leftUp, 1f);
            Gizmos.DrawSphere(_rightUp, 0.25f);
            Gizmos.DrawSphere(_leftBottom, 0.25f);
            Gizmos.DrawSphere(_rightBottom, 0.25f);
            Gizmos.DrawSphere(new Vector3(43.5f, 2.5f, 53.5f), 1f);

        }
    }
}

