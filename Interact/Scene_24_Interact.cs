using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;

namespace SilkRoad.Interact
{
    public class Scene_24_Interact : MonoBehaviour
    {
        GameObject stone;
        GameObject script;

        private void Start()
        {
            stone = transform.GetChild(0).gameObject;
            script = GameObject.FindGameObjectWithTag("Script");
        }

        public void StoneButtonPressed()
        {
            script.SetActive(true);
            script.GetComponent<ScriptController>().ScriptUpdate(1);
            Destroy(stone);
        }
    }
}
