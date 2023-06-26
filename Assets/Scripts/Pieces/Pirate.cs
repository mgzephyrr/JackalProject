using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Pirate : GamePiece
{
    public bool isCoin = false;

    public override List<Vector2Int> GetArrowsMoves(ref GamePiece[,] board, string type) 
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        if (type == "rightGrass")
        {
            if (board[currentX + 1, currentY] == null)
                locations.Add(new Vector2Int(currentX + 1, currentY));
            else if (board[currentX + 1, currentY].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY));
        }
        if (type == "leftGrass")
        {
            if (board[currentX - 1, currentY] == null)
                locations.Add(new Vector2Int(currentX - 1, currentY));
            else if (board[currentX - 1, currentY].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY));
        }
        if (type == "forwardGrass")
        {
            if (board[currentX, currentY - 1] == null)
                locations.Add(new Vector2Int(currentX, currentY - 1));
            else if (board[currentX, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX, currentY - 1));
        }
        if (type == "diagonal1Sand")
        {
            if (board[currentX - 1, currentY + 1] == null)
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
            else if (board[currentX - 1, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
        }
        if (type == "diagonal2Sand")
        {
            if (board[currentX + 1, currentY - 1] == null)
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
            else if (board[currentX + 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
        }
        if (type == "4diagonalsGrass")
        {
            if (board[currentX + 1, currentY + 1] == null) //вперед и вправо
                locations.Add(new Vector2Int(currentX + 1, currentY + 1));
            else if (board[currentX + 1, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY + 1));

            if (board[currentX + 1, currentY - 1] == null) //назад и вправо
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
            else if (board[currentX + 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));

            if (board[currentX - 1, currentY - 1] == null) //назад и влево
                locations.Add(new Vector2Int(currentX - 1, currentY - 1));
            else if (board[currentX - 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY - 1));

            if (board[currentX - 1, currentY + 1] == null) //вперед и влево
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
            else if (board[currentX - 1, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
        }
        if (type == "2diagonalsGrass")
        {
            if (board[currentX, currentY + 1] == null) //вперед
                locations.Add(new Vector2Int(currentX, currentY + 1));
            else if (board[currentX, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX, currentY + 1));

            if (board[currentX - 1, currentY] == null) //влево
                locations.Add(new Vector2Int(currentX - 1, currentY));
            else if (board[currentX - 1, currentY].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY));
        }
        if (type == "4diagonalsSand")
        {
            if (board[currentX + 1, currentY + 1] == null) //вперед и вправо
                locations.Add(new Vector2Int(currentX + 1, currentY + 1));
            else if (board[currentX + 1, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY + 1));

            if (board[currentX + 1, currentY - 1] == null) //назад и вправо
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
            else if (board[currentX + 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));

            if (board[currentX - 1, currentY - 1] == null) //назад и влево
                locations.Add(new Vector2Int(currentX - 1, currentY - 1));
            else if (board[currentX - 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY - 1));

            if (board[currentX - 1, currentY + 1] == null) //вперед и влево
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
            else if (board[currentX - 1, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY + 1));
        }
        if (type == "3diagonalsSand")
        {
            if (board[currentX - 1, currentY] == null) //влево
                locations.Add(new Vector2Int(currentX - 1, currentY));
            else if (board[currentX - 1, currentY].team != team)
                locations.Add(new Vector2Int(currentX - 1, currentY));

            if (board[currentX, currentY + 1] == null) //назад
                locations.Add(new Vector2Int(currentX, currentY + 1));
            else if (board[currentX, currentY + 1].team != team)
                locations.Add(new Vector2Int(currentX, currentY + 1));

            if (board[currentX + 1, currentY - 1] == null) //вперед и влево
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
            else if (board[currentX + 1, currentY - 1].team != team)
                locations.Add(new Vector2Int(currentX + 1, currentY - 1));
        }

        return locations;
    }
    public override List<Vector2Int> GetHorseMoves(ref GamePiece[,] board)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (board[currentX - 1, currentY + 2] == null)
            locations.Add(new Vector2Int(currentX - 1, currentY + 2));
        else if (board[currentX - 1, currentY + 2].team != team)
            locations.Add(new Vector2Int(currentX - 1, currentY + 2));

        if (board[currentX + 1, currentY + 2] == null)
            locations.Add(new Vector2Int(currentX + 1, currentY + 2));
        else if (board[currentX + 1, currentY + 2].team != team)
            locations.Add(new Vector2Int(currentX + 1, currentY + 2));

        if (board[currentX + 2, currentY - 1] == null)
            locations.Add(new Vector2Int(currentX + 2, currentY - 1));
        else if (board[currentX + 2, currentY - 1].team != team)
            locations.Add(new Vector2Int(currentX + 2, currentY - 1));

        if (board[currentX - 2, currentY + 1] == null)
            locations.Add(new Vector2Int(currentX - 2, currentY + 1));
        else if (board[currentX - 2, currentY + 1].team != team)
            locations.Add(new Vector2Int(currentX - 2, currentY + 1));

        if (board[currentX + 2, currentY + 1] == null)
            locations.Add(new Vector2Int(currentX + 2, currentY + 1));
        else if (board[currentX + 2, currentY + 1].team != team)
            locations.Add(new Vector2Int(currentX + 2, currentY + 1));

        if (board[currentX - 2, currentY - 1] == null)
            locations.Add(new Vector2Int(currentX - 2, currentY - 1));
        else if (board[currentX - 2, currentY - 1].team != team)
            locations.Add(new Vector2Int(currentX - 2, currentY - 1));

        if (board[currentX + 1, currentY - 2] == null)
            locations.Add(new Vector2Int(currentX + 1, currentY - 2));
        else if (board[currentX + 1, currentY - 2].team != team)
            locations.Add(new Vector2Int(currentX + 1, currentY - 2));

        if (board[currentX - 1, currentY - 2] == null)
            locations.Add(new Vector2Int(currentX - 1, currentY - 2));
        else if (board[currentX - 1, currentY - 2].team != team)
            locations.Add(new Vector2Int(currentX - 1, currentY - 2));

        return locations;
    }
    public override List<Vector2Int> GetAvailableMoves(ref GamePiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        //Right
        if (currentX + 1 < tileCountX)
        {
            if (board[currentX + 1, currentY] == null)
                r.Add(new Vector2Int(currentX + 1, currentY));
            else if(board[currentX + 1, currentY].team != team)
                r.Add(new Vector2Int(currentX + 1, currentY));

            //Top
            if (currentY + 1 < tileCountY)
                if (board[currentX + 1, currentY + 1] == null)
                    r.Add(new Vector2Int(currentX + 1, currentY+1));
                else if(board[currentX + 1, currentY + 1].team != team)
                    r.Add(new Vector2Int(currentX + 1, currentY + 1));
            //Bottom
            if (currentY - 1 >= 0)
                if (board[currentX + 1, currentY - 1] == null)
                    r.Add(new Vector2Int(currentX + 1, currentY - 1));
                else if (board[currentX + 1, currentY - 1].team != team)
                    r.Add(new Vector2Int(currentX + 1, currentY - 1));
        }

        //Left
        if (currentX - 1 >= 0)
        {
            if (board[currentX - 1, currentY] == null)
                r.Add(new Vector2Int(currentX - 1, currentY));
            else if (board[currentX - 1, currentY].team != team)
                r.Add(new Vector2Int(currentX - 1, currentY));

            //Top
            if (currentY + 1 < tileCountY)
                if (board[currentX - 1, currentY + 1] == null)
                    r.Add(new Vector2Int(currentX - 1, currentY + 1));
                else if (board[currentX - 1, currentY + 1].team != team)
                    r.Add(new Vector2Int(currentX - 1, currentY + 1));
            //Bottom
            if (currentY - 1 >= 0)
                if (board[currentX - 1, currentY - 1] == null)
                    r.Add(new Vector2Int(currentX - 1, currentY - 1));
                else if (board[currentX - 1, currentY - 1].team != team)
                    r.Add(new Vector2Int(currentX - 1, currentY - 1));
        }

        //Up
        if (currentY + 1 < tileCountY)
            if (board[currentX, currentY + 1] == null || board[currentX, currentY + 1].team != team)
                r.Add(new Vector2Int(currentX, currentY + 1));

        //Down
        if (currentY - 1 >= 0)
            if (board[currentX, currentY - 1] == null || board[currentX, currentY - 1].team != team)
                r.Add(new Vector2Int(currentX, currentY-1));

        return r;
    }
}
