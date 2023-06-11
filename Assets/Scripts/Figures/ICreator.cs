using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Figures
{
    public interface ICreator
    {
        public IFigure Create(Vector3 position, Quaternion rotation);
    }
}
