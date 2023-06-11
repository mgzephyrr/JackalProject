using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Figures
{
    public interface IFigure
    {
        public void Destroy(IDestruction destruction);
        public void Move(IMovement movement);
    }
}
