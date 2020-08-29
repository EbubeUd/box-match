using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEmitter : MonoBehaviour
{
    public GameObject BoxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        InvokeRepeating("SpawnBox", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBox()
    {
        Instantiate(BoxPrefab,transform.position, Quaternion.identity);
    }
}
