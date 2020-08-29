using Assets.Scripts.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameObjects
{
    public class FallingObject : MonoBehaviour
    {
        /// <summary>
        /// Determines the speed of the falling object
        /// </summary>
        [HideInInspector]
        public float Speed;

        /// <summary>
        /// Determines if the object can move in multiple directions or not
        /// </summary>
        [HideInInspector]
        public bool UseConstantDirection;

        /// <summary>
        /// Holds the angular velocity of the falling Object
        /// </summary>
        private float angularVelocity;

        /// <summary>
        /// Holds the velocity of the falling object
        /// </summary>
        private Vector2 velocity;

        /// <summary>
        /// An instance to the rigidbody of the object
        /// </summary>
        private Rigidbody2D rigidBody;



        public void SetRigidBody(Rigidbody2D _rigidbody)
        {
            rigidBody = _rigidbody;
            angularVelocity = 10;
            velocity = new Vector2() { x = 0, y = -3f };
        }


        private void LateUpdate()
        {
            if (rigidBody == null) return;
            if (GameManager.Instance.IsGamePaused)
            {
                rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                rigidBody.velocity = UseConstantDirection ? Speed * velocity : Speed * rigidBody.velocity.normalized;
                rigidBody.angularVelocity = angularVelocity;
            }
        }
    }
}
