using Assets.Scripts.Figures.FigurePirate;
using Assets.Scripts.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Utilities;
using Board;
using UnityEngine;

namespace Assets.Scripts.Board
{
    internal class CreatorFiguresOnBoard
    {
        private IFigure[,] _positions;
        private readonly SpecBoard _board;

        public CreatorFiguresOnBoard(SpecBoard board, IPositionKeeper positionKeeper)
        {
            _board = board;
            CreateFigures(positionKeeper);
        }
        private void CreateFigures(IPositionKeeper positionKeeper)
        {
            _positions = new IFigure[_board.NumberCellsX, _board.NumberCellsZ];
            for (int z = 0; z < _board.NumberCellsZ; z++)
            {
                for (int x = 0; x < _board.NumberCellsX; x++)
                {
                    _positions[x,z] = positionKeeper.Creators[x,z].Create(new Vector3(x,0,z), Quaternion.identity);
                }
            }
            //_positions[7,1] = null;
        }
    }
}
