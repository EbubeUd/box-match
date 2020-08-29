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
        public static List<List<Box>> SpawnedBoxes= new List<List<Box>>();  

        List<Box> BoxesToDestroy = new List<Box>();

        void DetectMatchingBoxes()
        { 
            //Detect on the vertical
            for(int c = 0; c< 4; c++)
            {
                BoxType firstBoxType = SpawnedBoxes[c][0].GetBoxType();
                bool isMatch = true;
                for (int r = 0; r<4; r++)
                {
                    if(SpawnedBoxes[c][r].GetBoxType() != firstBoxType)
                    {
                        isMatch = false;
                        break;
                    }
                }
                if(isMatch)
                {
                    BoxesToDestroy.AddRange(SpawnedBoxes[c]);
                    SpawnedBoxes[c].RemoveRange(0, 4);
                }
            }

            for(int i = 0; i<4; i++)
            {
                BoxType firstBoxType = SpawnedBoxes[0][0].GetBoxType();
                bool isMatch = true;
                for(int j = 0; j<4; j++)
                {
                    if(SpawnedBoxes[j][i].GetBoxType() != firstBoxType)
                    {

                    }
                }
            }
        }

        void DestroyBoxesInColumn(int column)
        {
            for(int i = 0; i<4; i++)
            {
                BoxesToDestroy.Add(SpawnedBoxes[i][column]);
            }
        }

        void DestroyBoxesInRow(int row)
        {
            for(int i = 0; i<4; i++)
            {
                BoxesToDestroy.Add(SpawnedBoxes[row][i]);
            }
        }

        public void AddBox(ColumnType column, Box box)
        {
        
        }

        public void DestroyBoxes()
        {
            for(int i = 0; i<BoxesToDestroy.Count; i++)
            {
                if (BoxesToDestroy[i] != null) BoxesToDestroy[i].DestroyBox();               
            }
            BoxesToDestroy.Clear();
        }
    }
}
