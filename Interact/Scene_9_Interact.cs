using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_9_Interact : MonoBehaviour
    {
        [SerializeField] GameObject silver_button;
        ScriptController sc;
        GameObject script;
        PlayerUIController playerui;
        Portal portal;

        private void Start()
        {
            sc = FindObjectOfType<ScriptController>();
            script = GameObject.FindGameObjectWithTag("Script");
            playerui = FindObjectOfType<PlayerUIController>();
            sc.onFinish += End;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
        }

        public void SilverButtonPressed()
        {
            Destroy(silver_button);
            script.SetActive(true);
            sc.ScriptUpdate(1);
            playerui.PackageButtonPressed();
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(11);
        }
    }
}
