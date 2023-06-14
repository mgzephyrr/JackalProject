using Assets.Scripts.Figures.FigurePirate;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

namespace Assets.Scripts.Figures
{
    public class PirateMovementlogic : IMovementLogic
    {
        private Vector3 _positionFigure;
        private Vector3 _positionMovement;
        private SpecBoard _board;
        public PirateMovementlogic(Vector3 _positionFigure, Vector3 _positionMovement,  SpecBoard _board) 
        {
        }

        public bool CheckMovement()
        {
            return false;
        }

    }
}

