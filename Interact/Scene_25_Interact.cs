using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_25_Interact : MonoBehaviour
    {
        [SerializeField] GameObject stone;
        GameObject script;
        PlayerUIController py;
        Portal portal;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            py = FindObjectOfType<PlayerUIController>();
            script.GetComponent<ScriptController>().onFinish += End;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
        }

        public void StoneButtonPressed()
        {
            Destroy(stone);
            script.SetActive(true);
            script.GetComponent<ScriptController>().ScriptUpdate(1);
            py.PackageButtonPressed();
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(26);
        }
    }
}
