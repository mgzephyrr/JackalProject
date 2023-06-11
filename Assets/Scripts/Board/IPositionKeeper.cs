using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Figures;
using Assets.Scripts.Figures.FigurePirate;

namespace Board
{
    public interface IPositionKeeper
    {
        public ICreator[,] Creators { get; }
    }
}

