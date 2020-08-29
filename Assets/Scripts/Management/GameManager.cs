using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Management
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [HideInInspector]
        public bool IsGamePaused;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }
    }
}
