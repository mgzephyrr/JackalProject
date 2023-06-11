using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Figures
{
    internal class Destruction : IDestruction
    {
        private readonly GameObject _gameobject;
        public Destruction(GameObject gameobject)
        {
            _gameobject = gameobject;
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(_gameobject);
        }
    }
}
