using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Bullet class defines a bullet that is used in this game
 */
public class Bullet : MonoBehaviour
{
    // Called when this bullet is no longer visible to the camera
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
