using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Gun class defines a gun used in this game
 */
public class Gun : MonoBehaviour
{
    // Called before the first frame update
    void Start()
    {
        
    }


    // Called once per frame
    void Update()
    {

    }


    // Fires this gun
    public void Fire()
    {
        Debug.Log( name + " Fired.");
    }
}
