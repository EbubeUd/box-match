using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

namespace Assets.Scripts.GameObjects.Boxes
{
    public class Box : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        BoxHolder parentHolder;
        public Sprite Sprite;

       
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite;
            parentHolder = transform.parent.gameObject.GetComponent<BoxHolder>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                DelegateHandler.BoxDestroyed(parentHolder.ColumnType, parentHolder.BoxType);
                Destroy(collision.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }

     
    
    }

}