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
                Destroy(collision.gameObject);
                DestroyBox();
            }
        }


        public void DestroyBox()
        {
            DelegateHandler.BoxDestroyed(parentHolder.ColumnType, parentHolder.BoxType);
            Destroy(transform.parent.gameObject);
        }

     
    
    }

}