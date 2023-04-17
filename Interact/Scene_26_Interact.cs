using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_26_Interact : MonoBehaviour
    {
        GameObject script;
        Portal portal;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            script.GetComponent<ScriptController>().onFinish += End;
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(27);
        }
    }
}
