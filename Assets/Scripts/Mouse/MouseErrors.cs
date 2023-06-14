using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.HandlerMove
{
    public class MouseErrors: Exception
    {
        public MouseErrors(string message) : base(message) 
        { 
        }
    }

    public class InCorrectPositionOfFigure : MouseErrors
    {
        public InCorrectPositionOfFigure(string message) : base(message)
        {
        }
    }
    public class UnknownFigure : MouseErrors
    {
        public UnknownFigure(string message) : base(message)
        {
        }
    }
}
