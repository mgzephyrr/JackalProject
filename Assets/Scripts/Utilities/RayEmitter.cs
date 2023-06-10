using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class RayEmitter: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpecBoard _board;
        private Vector3 _pointHit;
        private void Update()
        {

            if (!Input.GetMouseButtonDown(0)) return;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                _pointHit = hit.point;
                print($"{_pointHit}");
                print($"{Mathf.Round(_pointHit.z/_board.SizeCellZ)} {Mathf.Round(_pointHit.x/_board.SizeCellX)}");
            }
            
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _pointHit);
        }
    }
}
