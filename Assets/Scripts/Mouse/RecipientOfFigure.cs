using Assets.Scripts.Board;
using Assets.Scripts.Figures;
using Assets.Scripts.Utilities;
using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.HandlerMove
{
    ///<summary>
    /// Подаем на вход точку мыши 
    /// После обработки получаем 
    /// После обработки получаем пирата на которго нажали
    /// Если точка нажатияб не является точкой фигуры, выкидываем исключение.
    ///</summary>

    public class RecipientOfFigure
    {
        private readonly Camera _camera;
        private readonly SpecBoard _board;
        private readonly IPositionKeeper _positionKeeper;

        public RecipientOfFigure(Camera camera, SpecBoard specBoard, IPositionKeeper positionKeeper)
        {
            _camera = camera;
            _board = specBoard;
            _positionKeeper = positionKeeper;
        }

        public IFigure GetFigure(Vector3 mousePosition)
        {
            Vector3 point = GetTouchPointWithBoard(mousePosition);
            var boardPoint = TranslateToBoardCoordinates(point);
            IFigure selected = _positionKeeper.Figures[boardPoint.x, boardPoint.y];
            if (selected == null)
            {
                throw new UnknownFigure("Неизвестная фигура");
            }
            return selected;
        }
        private Vector3 GetTouchPointWithBoard(Vector3 mousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity))
            {
                return hit.point;
            }
            throw new InCorrectPositionOfFigure("Неправильные координаты");
        }

        private Vector2Int TranslateToBoardCoordinates( Vector3 touchPoint)
        {
            int x = Mathf.RoundToInt(touchPoint.z / _board.SizeCellZ);
            int y = Mathf.RoundToInt(touchPoint.x / _board.SizeCellX);
            return new Vector2Int(x, y);
        }
    }
}
