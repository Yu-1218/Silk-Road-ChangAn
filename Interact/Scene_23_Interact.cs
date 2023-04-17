using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;

namespace SilkRoad.Interact
{
    public class Scene_23_Interact : MonoBehaviour
    {
        [SerializeField] GameObject li;
        [SerializeField] GameObject seng;
        [SerializeField] GameObject shami;
        bool trigger = false;
        GameObject script;
        GameObject pearl;
        bool if_pearl = false;
        bool stop_0 = false;
        bool stop_1 = false;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            pearl = transform.GetChild(0).gameObject;
            pearl.SetActive(false);
        }

        private void Update()
        {
            if (trigger == false && Vector2.Distance(li.transform.position, seng.transform.position) < 6.4)
            {
                script.SetActive(true);
                script.GetComponent<ScriptController>().ScriptUpdate(1);
                shami.GetComponent<SpriteRenderer>().flipX = true;
                trigger = true;
            }

            if (if_pearl == false && script.GetComponent<ScriptController>().text_index == 27)
            {
                pearl.SetActive(true);
                if_pearl = true;
            }

            if (stop_0 == false && script.GetComponent<ScriptController>().text_index == 30)
            {
                Invoke("Continue_1", 2);
                stop_0 = true;
            }

            if (stop_1 == false && script.GetComponent<ScriptController>().text_index == 32)
            {
                Invoke("Continue_1", 2);
                stop_1 = true;
            }
        }

        private void Continue_1()
        {
            script.SetActive(true);
            script.GetComponent<ScriptController>().ScriptUpdate(1);
        }

        public void PearlButtonPressed()
        {
            Destroy(pearl);
            script.SetActive(true);
            script.GetComponent<ScriptController>().ScriptUpdate(1);
        }

    }
}
