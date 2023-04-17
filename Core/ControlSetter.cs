using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Movement;

namespace SilkRoad.Core
{
    public class ControlSetter : MonoBehaviour
    {
        GameObject player;

        void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
        }

        public void DisablePlayerControl()
        {
            player.GetComponent<PlayerController>().StopAnimation();
            player.GetComponent<PlayerController>().enabled = false;
        }

        public void EnablePlayerControl()
        {
            player.GetComponent<PlayerController>().enabled = true;
        }

        public ControlSetter GetOtherCS()
        {
            foreach (ControlSetter cs in FindObjectsOfType<ControlSetter>())
            {
                if (cs == this) continue;

                return cs;
            }
            return null;
        }
    }
}
