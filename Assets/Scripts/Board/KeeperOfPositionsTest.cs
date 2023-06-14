using Assets.Scripts.Figures.FigurePirate;
using Assets.Scripts.Figures;
using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Board
{
    public class KeeperOfPositionsTest : MonoBehaviour, IPositionKeeper
    {
        //public KeeperOfFigures Keeper => _keeper;
        //public ICreator[,] Creators { get; private set; }
        public IFigure[,] Figures { get; private set; }
        [SerializeField] private GameObject _prefabForWhite;
        [SerializeField] private GameObject _prefabForRed;
        [SerializeField] private GameObject _prefabForBlack;
        [SerializeField] private GameObject _prefabForBlue;
        [SerializeField] private Transform _parent;        
        [SerializeField] private SpecBoard _board;

        //private KeeperOfFigures _keeper;

        public void Awake() 
        {
            ICreator[,] creators =
            {
                { //0x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorPirate(_prefabForRed, _parent),
                    new CreatorPirate(_prefabForRed, _parent),
                    new CreatorPirate(_prefabForRed, _parent),
                    new CreatorEmptyCell(), 
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()

                },
                {//1x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                },
                {//2x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                },
                {//3x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//4x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//5x
                    new CreatorPirate(_prefabForWhite,_parent),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//6x
                    new CreatorPirate(_prefabForWhite,_parent),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//7x
                    new CreatorPirate(_prefabForWhite,_parent),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//8x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//9x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//10x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//11x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
                {//12x
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell(),
                    new CreatorEmptyCell()
                },
            };
            CreateFigures(creators);
        }
        private void CreateFigures(ICreator[,] creators)
        {
            Figures = new IFigure[_board.NumberCellsX, _board.NumberCellsZ];
            for (int z = 0; z < _board.NumberCellsZ; z++)
            {
                for (int x = 0; x < _board.NumberCellsX; x++)
                {
                    Figures[x, z] = creators[x, z].Create(new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
    }
}
