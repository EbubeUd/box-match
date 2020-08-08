using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite Sprite;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.sprite = Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
