using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Figures;
using Assets.Scripts.Figures.FigurePirate;
using Assets.Scripts.Board;

namespace Board
{
    public interface IPositionKeeper
    {
        public IFigure[,] Figures { get;}
    }
}

