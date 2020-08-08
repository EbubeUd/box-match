using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Weapons
{
    public class Trigger : MonoBehaviour
    {
        private void Update()
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    Debug.Log("Something Hit");
                    if (raycastHit.collider.name == "Trigger")
                    {
                        Debug.Log("Soccer Ball clicked");
                    }

                    //OR with Tag
                    if (raycastHit.collider.CompareTag("Trigger"))
                    {
                        Debug.Log("Soccer Ball clicked");
                    }
                }
            }
        }
    }
}
