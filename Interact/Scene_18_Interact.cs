using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_18_Interact : MonoBehaviour
    {
        [SerializeField] GameObject li;
        [SerializeField] GameObject shi;
        bool first_trigger = false;
        bool second_trigger = false;
        GameObject script;
        Portal portal;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            script.GetComponent<ScriptController>().onFinish += End;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
        }

        private void Update()
        {
            if (first_trigger == false && Vector2.Distance(li.transform.position, shi.transform.position) < 8)
            {
                script.SetActive(true);
                script.GetComponent<ScriptController>().ScriptUpdate(1);
                first_trigger = true;
            }

            if (second_trigger == false && Vector2.Distance(li.transform.position, shi.transform.position) < 3)
            {
                script.SetActive(true);
                script.GetComponent<ScriptController>().ScriptUpdate(1);
                shi.GetComponent<SpriteRenderer>().flipX = false;
                second_trigger = true;
            }
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(19);
        }

    }
}
