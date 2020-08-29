using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

namespace Assets.Scripts.GameObjects
{
    public class Box : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        public Sprite Sprite;
       
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }

     
    
    }

}