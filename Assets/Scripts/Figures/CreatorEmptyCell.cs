using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Figures
{
    public class CreatorEmptyCell : ICreator
    {
        public IFigure Create(Vector3 position, Quaternion rotation)
        {
            return null;
        }

    }
}

