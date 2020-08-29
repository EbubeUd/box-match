using Assets.Scripts.Enums;
using Assets.Scripts.GameObjects.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class MatchingSystem : MonoBehaviour
    {
        public static Box[,] SpawnedBoxes= new Box[4, 4];// 4 rows and 4 cols


        void DetectMatchingBoxes()
        {

            //detect on the horizontal axis
            for(int r = 0; r<4; r++)
            {
                BoxType currentType = SpawnedBoxes[r, 0].GetBoxType();
                bool isMatch = true;
                for (int j = 0; j<4; j++)
                {
                    if(SpawnedBoxes[r,j].GetBoxType() != currentType)
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    DestroyBoxesInRow(r);
                }
            }

            
        }

        void DestroyBoxesInColumn(int column)
        {

        }

        void DestroyBoxesInRow(int row)
        {
            for(int i = 0; i<4; i++)
            {
                SpawnedBoxes[row, i].DestroyBox();
            }
        }

        public void AddBox()
        {

        }
    }
}
