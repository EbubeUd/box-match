using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * DelegateHandler class defines the delegates that are used in this game
 */
public class DelegateHandler : MonoBehaviour
{
    // Declaration of the delegate that is meant to be invoked whenever a gun is fired
    public delegate void OnGunFired();


    // Instance of the OnGunFired delegate
    public static OnGunFired GunFired;



}
