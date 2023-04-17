using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_16_Interact : MonoBehaviour
    {
        [SerializeField] GameObject script;
        ControlSetter cs;
        Portal portal;


        private void Start()
        {
            cs = FindObjectOfType<ControlSetter>();
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            script.GetComponent<ScriptController>().onFinish += End;
        }

        // public void ButtonPressed()
        // {
        //     Destroy(click_button);
        //     script.SetActive(true);
        //     script.GetComponent<ScriptController>().ScriptUpdate(0);
        //     script.GetComponent<ScriptController>().onFinish += End;
        // }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(17);
        }

    }
}
