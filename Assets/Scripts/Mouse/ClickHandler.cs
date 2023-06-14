using Assets.Scripts.Board;
using Assets.Scripts.Figures;
using Assets.Scripts.HandlerMove;
using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mouse
{
    public class ClickHandler: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpecBoard _board;
        [SerializeField] private KeeperOfPositionsTest _keeperOfPositions;
        private RecipientOfFigure _recipient;

        private void Start()
        {
            _recipient = new RecipientOfFigure(_camera, _board, _keeperOfPositions);
        }
        private void Update()
        {
            if(Input.GetMouseButton(0) == false) { return; }
            IFigure figure = _recipient.GetFigure(Input.mousePosition);
            print($"Figure: {figure}");
        }
    }
}

