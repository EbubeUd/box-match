using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Gun class defines a gun used in this game
 */
public class Gun : MonoBehaviour
{
    // Reference to the prefab that is used as a blueprint for spawning bullets
    public Rigidbody2D PrefabOfBullet;


    // Bullet that has been spawned and made ready to be launched
    private Rigidbody2D LaunchableBullet;


    // Velocity at which this gun launches its bullets
    private Vector2 LaunchVelocity;


    // Called before the first frame update
    private void Start()
    {
        LaunchVelocity = new Vector2(0, 25);
        SpawnLaunchableBullet();
    }
    

    // Spawns a launchable bullet
    private void SpawnLaunchableBullet()
    {
        LaunchableBullet = Instantiate(PrefabOfBullet, GetPositionOfNozzle(), Quaternion.identity);
    }


    // Returns the position of this gun's nozzle
    private Vector3 GetPositionOfNozzle()
    {
        Transform thisGameObject = this.gameObject.transform;
        Vector3 positionOfNozzle = thisGameObject.position;

        for (int i = 0; i < thisGameObject.childCount; i++) {

            if (thisGameObject.GetChild(i).name == "Nozzle") {
                positionOfNozzle = thisGameObject.GetChild(i).position;
                break;
            }
        }

        return positionOfNozzle;
    }


    // Fires this gun
    public void Fire()
    {
        if (LaunchableBullet != null) {
            LaunchBullet();
            Invoke("SpawnLaunchableBullet", 0.5f);
        }
    }


    // Launches the current launchable bullet
    private void LaunchBullet()
    {
        if (LaunchableBullet != null) {
            LaunchableBullet.isKinematic = false;
            LaunchableBullet.velocity = LaunchVelocity;
            LaunchableBullet = null;
        }
    }
}
