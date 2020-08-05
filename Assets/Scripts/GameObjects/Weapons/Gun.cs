using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gun class defines the gun used in this game
public class Gun : MonoBehaviour
{
    // Flag that indicates whether or not this gun is idle
    bool IsIdle;


    // Start is called before the first frame update
    void Start()
    {
        IsIdle = true;
    }


    // Update is called once per frame
    void Update()
    {
        //if (IsIdle && TriggerIsPulled()) {
        //    Debug.Log("Fired");
        //}

        //IsIdle = !TriggerIsPulled();
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


    // Returns true if the trigger of this gun is pulled, returns false otherwise
    bool TriggerIsPulled()
    {
        return Input.GetAxis("PullTrigger") > 0;
    }
}
