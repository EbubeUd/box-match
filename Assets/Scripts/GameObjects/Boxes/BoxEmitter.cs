using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Boxes
{
    public class BoxEmitter : MonoBehaviour
    {
        public GameObject BoxPrefab;
        public ColumnType ColumnType;

        // Start is called before the first frame update
        void Start()
        {
            DelegateHandler.BoxDestroyed += OnBoxDestroyed;
            SpawnInitialBoxes();
        }


  
        void SpawnInitialBoxes()
        {
            for(int i = 0; i<4; i++)
            {
                Invoke("SpawnBox", i*0.3f);
            }
        }


        void OnBoxDestroyed(ColumnType columnType, BoxType boxType)
        {
            if (columnType != ColumnType) return;
            Invoke("SpawnBox", 0.3f);
        }

        void SpawnBox()
        {
            GameObject boxHolderObject = Instantiate(BoxPrefab, transform.position, Quaternion.identity);
            BoxHolder boxHolder = boxHolderObject.GetComponent<BoxHolder>();
            boxHolder.ColumnType = ColumnType;
            boxHolder.BoxType = BoxType.A;
        }


        private void OnDestroy()
        {
            DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
        }
    }
}