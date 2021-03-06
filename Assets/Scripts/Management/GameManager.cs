using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Management
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [HideInInspector]
        public bool IsGamePaused;
        public System.Random Rand;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Rand = new System.Random();
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        void PauseGame(bool status)
        {
            IsGamePaused = status;
        }

    }

}