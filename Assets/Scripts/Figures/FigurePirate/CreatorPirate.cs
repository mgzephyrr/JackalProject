using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Figures.FigurePirate
{
    internal class CreatorPirate : ICreator
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        public CreatorPirate(GameObject prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }
        public IFigure Create(Vector3 position, Quaternion rotation)
        {
            GameObject pirate = UnityEngine.Object.Instantiate(_prefab, _parent, false);
            pirate.transform.localPosition = position;
            pirate.transform.rotation = rotation;
            return pirate.GetComponent<IFigure>();
        }
    }
}
