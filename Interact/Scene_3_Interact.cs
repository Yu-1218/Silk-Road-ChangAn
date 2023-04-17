using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_3_Interact : MonoBehaviour
    {
        GameObject Script;
        ScriptController script_controller;
        GameObject select_0;
        bool if_select_0 = false;
        Portal portal;
        [SerializeField] GameObject select_audio;
        [SerializeField] AnimationClip disappear;

        private void Start()
        {
            Script = GameObject.FindGameObjectWithTag("Script");
            script_controller = FindObjectOfType<ScriptController>();
            select_0 = transform.GetChild(0).gameObject;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            script_controller.onFinish += EndScene;
        }

        private void Update()
        {
            if (script_controller.text_index == 15 && if_select_0 == false)
            {
                select_0.SetActive(true);
                if_select_0 = true;
            }
        }

        public void BringSilkButton()
        {
            select_0.GetComponent<Animator>().SetBool("Disappear", true);
            select_audio.GetComponent<AudioSource>().Play();
            Invoke("RestoreSilk", disappear.length);
        }

        public void BringChinaButton()
        {
            select_0.GetComponent<Animator>().SetBool("Disappear", true);
            select_audio.GetComponent<AudioSource>().Play();
            Invoke("RestoreChina", disappear.length);
        }

        private void RestoreChina()
        {
            Destroy(select_0);
            Script.SetActive(true);
            script_controller.ScriptUpdate(18);
        }

        private void RestoreSilk()
        {
            Destroy(select_0);
            Script.SetActive(true);
            script_controller.ScriptUpdate(16);
        }

        public void EndScene(float sig)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(4);
        }
    }
}
