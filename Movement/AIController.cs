using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;

namespace SilkRoad.Movement
{
    public class AIController : MonoBehaviour
    {
        private float movementX = 1;
        private float moveForce = 5;
        private SpriteRenderer sr;
        private Animator anim;
        private string WALK_ANIMATION = "Walk";

        [SerializeField]
        private float maxX, minX;

        ScriptController script_controller;
        bool if_leave = false;
        bool if_coming = false;
        [SerializeField] int time_to_leave = -1;
        [SerializeField] int second_time_to_leave = -1;
        [SerializeField] int time_to_come = -1;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            script_controller = FindObjectOfType<ScriptController>();
        }

        private void Update()
        {
            if ((script_controller.text_index == time_to_leave || script_controller.text_index == second_time_to_leave)
            && if_leave == false)
            {
                StartCoroutine("AILeave");
                if_leave = true;
            }
            if (if_coming == false && time_to_come != 0 && script_controller.text_index == time_to_come)
            {
                StartCoroutine("AICome");
                if_coming = true;
            }
        }

        IEnumerator AICome()
        {
            Vector2 pos = transform.position;
            while (pos.x > minX)
            {
                movementX = -1;
                pos.x += movementX * Time.deltaTime * moveForce;
                if (pos.x < minX)
                {
                    break;
                }
                transform.position = pos;
                AnimatePlayer();
                yield return null;
            }
            movementX = 0;
            AnimatePlayer();
        }

        IEnumerator AILeave()
        {
            Vector2 pos = transform.position;
            movementX = 1;
            while (pos.x < maxX)
            {
                pos.x += movementX * Time.deltaTime * moveForce;
                if (pos.x > maxX)
                {
                    Destroy(gameObject);
                }
                transform.position = pos;
                AnimatePlayer();
                yield return null;
            }
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
    }
}
