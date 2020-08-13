using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * Trigger class defines a trigger that can be used to fire the gun
 */
public class Trigger : MonoBehaviour
{
    // The gun that this trigger is attached to
    Gun parentGun;


    // Called before the first frame update
    void Start()
    {
        Transform parent = this.gameObject.transform.parent;

        if (parent != null) {
            parentGun = parent.gameObject.GetComponent<Gun>();
        }

        if (parent == null || parentGun == null) {
            Destroy(this.gameObject);
        }
    }


    // Called once per frame
    void Update()
    {
        if (this.IsPulled()) {
            parentGun.Fire();
        }
    }


    // Returns true if this trigger is pulled, returns false otherwise
    bool IsPulled()
    {
        if (CustomLibrary.NoInputIsDetected()) {
            return false;
        }

        RaycastHit2D objectAtPosition;
        Vector2[] inputPositions = CustomLibrary.GetInputPositions();

        foreach (Vector2 position in inputPositions) {
            objectAtPosition = Physics2D.Raycast(position, Vector2.zero);

            if (objectAtPosition.collider != null && objectAtPosition.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()) {
                return true;
            }
        }

        return false;
    }
}
