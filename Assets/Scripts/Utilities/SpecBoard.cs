using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Utilities
{
    public class SpecBoard : MonoBehaviour
    {
        public int NumberCellsX => _numberCellsX;
        public int NumberCellsZ => _numberCellsZ;
        public float SizeCellZ => SizeZ / _numberCellsX;
        public float SizeCellX => SizeX / _numberCellsZ;
        public float SizeX => Vector3.Distance(_leftUp, _leftBottom);
        public float SizeZ => Vector3.Distance(_rightUp, _leftUp);

        [SerializeField, Range(0,14)] private int _numberCellsX;

        [SerializeField, Range(0,14)] private int _numberCellsZ;

        private Vector3 _leftUp;
        private Vector3 _rightUp;
        private Vector3 _leftBottom;
        private Vector3 _rightBottom;
        private Renderer _renderer;
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            Bounds bounds = _renderer.bounds;
            _leftUp =  new Vector3(0, 2.5f, 13);
            _rightUp = new Vector3(13, 2.5f, 13);
            _leftBottom = new Vector3(0, 2.5f, 0);
            _rightBottom =  new Vector3(13, 2.5f, 0);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = UnityEngine.Color.red;
            Gizmos.DrawSphere(_leftUp, 0.5f);
            Gizmos.DrawSphere(_rightUp, 0.75f);
            Gizmos.DrawSphere(_leftBottom, 0.25f);
            Gizmos.DrawSphere(_rightBottom, 1f);
        }
    }
}

