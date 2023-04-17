using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Movement
{
    public class PlayerController : MonoBehaviour
    {
        private float movementX;
        private float moveForce = 3;
        private SpriteRenderer sr;
        private Animator anim;
        private string WALK_ANIMATION = "Walk";

        [SerializeField]
        private float minX, maxX;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            playerMovementKeyboard();
            AnimatePlayer();
        }

        void playerMovementKeyboard()
        {
            movementX = Input.GetAxisRaw("Horizontal");
            Vector2 pos = transform.position;
            pos.x += movementX * Time.deltaTime * moveForce;
            if (pos.x < minX)
            {
                pos.x = minX;
            }
            if (pos.x > maxX)
            {
                pos.x = maxX;
            }
            transform.position = pos;

        }

        void AnimatePlayer()
        {
            if (movementX > 0)
            {
                sr.flipX = true;
                anim.SetBool(WALK_ANIMATION, true);
            }

            else if (movementX < 0)
            {
                sr.flipX = false;
                anim.SetBool(WALK_ANIMATION, true);
            }

            else
            {
                anim.SetBool(WALK_ANIMATION, false);
            }
        }

        public void StopAnimation()
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
