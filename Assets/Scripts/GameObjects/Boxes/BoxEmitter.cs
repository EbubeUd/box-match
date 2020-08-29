using Assets.Scripts.Enums;
using Assets.Scripts.Logic;
using Assets.Scripts.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Boxes
{
    public class BoxEmitter : MonoBehaviour
    {
        public GameObject BoxPrefab;
        public ColumnType ColumnType;
        int queuedSpawnCount;

        // Start is called before the first frame update
        void Start()
        {
            queuedSpawnCount = 0;
            DelegateHandler.BoxDestroyed += OnBoxDestroyed;
            Invoke("SpawnInitialBoxes", 1);
            InvokeRepeating("SpawnAdditionalBoxes", 6, 0.5f);
        }



        void SpawnInitialBoxes()
        {
            for(int i = 0; i<4; i++)
            {
                Invoke("SpawnBox", i*0.3f);
            }
        }

        void SpawnAdditionalBoxes()
        {
            if (queuedSpawnCount == 0) return;
            int boxesToSpawn = queuedSpawnCount;
            for (int i = 0; i< boxesToSpawn; i++)
            {
                Invoke("SpawnBox", i * 0.3f);
                queuedSpawnCount--;
            }
            MatchingSystem.Instance.Invoke("DetectMatchingBoxes", boxesToSpawn);
        }

        void OnBoxDestroyed(ColumnType columnType, BoxType boxType)
        {
            if (columnType != ColumnType) return;
            queuedSpawnCount++;
            //Invoke("SpawnBox", 0.3f);
        }

        void SpawnBox()
        {
            GameObject boxHolderObject = Instantiate(BoxPrefab, transform.position, Quaternion.identity);
            BoxHolder boxHolder = boxHolderObject.GetComponent<BoxHolder>();
            boxHolder.ColumnType = ColumnType;
            boxHolder.BoxType = (BoxType)GameManager.Instance.Rand.Next(0, 3);

        }


        private void OnDestroy()
        {
            DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
        }
    }
}