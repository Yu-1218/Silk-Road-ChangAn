using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_28_Interact : MonoBehaviour
    {
        GameObject script;
        Portal portal;
        bool if_flip = false;
        [SerializeField] GameObject cao;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            script.GetComponent<ScriptController>().onFinish += End;
        }

        private void Update()
        {
            if (if_flip == false && script.GetComponent<ScriptController>().text_index == 4)
            {
                cao.GetComponent<SpriteRenderer>().flipX = true;
                if_flip = true;
            }
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(29);
        }
    }
}
