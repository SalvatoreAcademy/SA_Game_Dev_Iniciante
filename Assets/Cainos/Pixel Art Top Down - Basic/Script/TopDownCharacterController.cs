using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        internal int direction = 0;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                direction = 3;
                animator.SetInteger("Direction", direction);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                direction = 2;
                animator.SetInteger("Direction", direction);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                direction = 1;
                animator.SetInteger("Direction", direction);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                direction = 0;
                animator.SetInteger("Direction", direction);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().linearVelocity = speed * dir;
        }
    }
}
