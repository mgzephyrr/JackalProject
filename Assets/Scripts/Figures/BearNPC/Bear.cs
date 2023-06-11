using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Figures.BearNPC
{
    internal class Bear : IFigure
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
