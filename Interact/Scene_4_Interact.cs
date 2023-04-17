using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_4_Interact : MonoBehaviour
    {
        GameObject player;
        [SerializeField] GameObject target;
        GameObject script;
        ScriptController script_controller;
        bool trigger = false;
        Portal portal;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            script = GameObject.FindWithTag("Script");
            script_controller = FindObjectOfType<ScriptController>();
            portal = FindObjectOfType<Portal>().GetOtherPortal();
        }

        private void Update()
        {
            if (trigger == false && Vector2.Distance(player.transform.position, target.transform.position) < 6)
            {
                script.SetActive(true);
                script_controller.ScriptUpdate(4);
                trigger = true;
            }
        }


    }
}
