using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Figures.FigurePirate
{
    internal class Pirate : MonoBehaviour, IFigure
    {
        public void Destroy(IDestruction destruction)
        {
            destruction.Destroy();
        }

        public void Move(IMovement movement)
        {
            movement.Move();
        }
    }
}
