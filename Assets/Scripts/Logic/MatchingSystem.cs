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




        public static MatchingSystem Instance;
        public static List<List<Box>> SpawnedBoxes;
        List<Box> BoxesToDestroy;
        bool isBeingModified;
        
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }


        private void Start()
        {
            SpawnedBoxes = new List<List<Box>>();
            for (int i = 0; i < 4; i++)
            {
                SpawnedBoxes.Add(new List<Box>());
            }
            BoxesToDestroy = new List<Box>();
            Invoke("DetectMatchingBoxes", 3f);
          
        }



        void DetectMatchingBoxes()
        {
            try
            {

                if (isBeingModified) return;
                bool matchFound = false;
                Debug.Log("Detecting Match...");

                //Detect on the vertical
                for (int c = 0; c < 4; c++)
                {

                    BoxType firstBoxType = SpawnedBoxes[c][0].GetBoxType();
                    bool isMatch = true;
                    for (int r = 0; r < 4; r++)
                    {
                        if (SpawnedBoxes[c][r].GetBoxType() != firstBoxType)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                    {
                        isBeingModified = true;
                        Debug.Log("Adding Objects in col for destruction");
                        BoxesToDestroy.AddRange(SpawnedBoxes[c]);
                        //SpawnedBoxes[c].RemoveRange(0, 4);
                        matchFound = true;
                    }


                }

                //Detect on Horizontal
                for (int r = 0; r < 4; r++)
                {

                    BoxType firstBoxType = SpawnedBoxes[0][r].GetBoxType();
                    bool isMatch = true;
                    for (int c = 0; c < 4; c++)
                    {
                        if (SpawnedBoxes[c][r].GetBoxType() != firstBoxType)
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
                        matchFound = true;
                    }
                }

                if (matchFound) DestroyBoxes();
            }
            catch(Exception ex)
            {

            }

       
        }



        void DestroyBoxesInRow(int row)
        {
            isBeingModified = true;
            Debug.Log("Adding Objects in row for destruction");
            for(int i = 0; i<4; i++)
            {
                BoxesToDestroy.Add(SpawnedBoxes[i][row]);
                //SpawnedBoxes[i].Remove(SpawnedBoxes[i][row]);
            }
        }

        public void AddBox(ColumnType column, Box box)
        {
            isBeingModified = true;
            int col = (int)column;
            SpawnedBoxes[col].Add(box);
            if (SpawnedBoxes[col].Count > 4) SpawnedBoxes[col].Remove(SpawnedBoxes[col][0]);
            isBeingModified = false;
        }


        public void DestroyBoxes()
        {
            Debug.Log("Destroying Boxes");
            for (int i = 0; i<BoxesToDestroy.Count; i++)
            {
                for(int j = 0; j<4; j++) SpawnedBoxes[j].Remove(BoxesToDestroy[i]);
                if (BoxesToDestroy[i] != null) BoxesToDestroy[i].DestroyBox();               
            }
    
            BoxesToDestroy.Clear();
            isBeingModified = false;

        }
    }
}
