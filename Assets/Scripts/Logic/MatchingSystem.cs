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
        bool isBeingModified;

        void DetectMatchingBoxes()
        {
            if (isBeingModified) return;
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

            //Detect on Horizontal
            for(int r = 0; r<4; r++)
            {
                BoxType firstBoxType = SpawnedBoxes[0][r].GetBoxType();
                bool isMatch = true;
                for(int c = 0; c<4; c++)
                {
                    if(SpawnedBoxes[c][r].GetBoxType() != firstBoxType)
                    {
                        isMatch = false;
                    }
                    else
                    {
       
                    }
                }
                if (isMatch)
                {
                    DestroyBoxesInRow(r);
                }
            }

            DestroyBoxes();
        }



        void DestroyBoxesInRow(int row)
        {
            for(int i = 0; i<4; i++)
            {
                BoxesToDestroy.Add(SpawnedBoxes[i][row]);
                SpawnedBoxes[i].Remove(SpawnedBoxes[i][row]);
            }
        }

        public void AddBox(ColumnType column, Box box)
        {
            isBeingModified = true;
            int col = (int)column;
            SpawnedBoxes[col].Remove(SpawnedBoxes[col][0]);
            SpawnedBoxes[col].Add(box);
            isBeingModified = false;
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
