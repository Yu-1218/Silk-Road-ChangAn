using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_13_Interact : MonoBehaviour
    {
        [SerializeField] GameObject silver;
        [SerializeField] GameObject yuanbao;
        GameObject script;
        ScriptController script_controller;
        PlayerUIController playerui;
        Portal portal;
        GameObject select_0;
        bool if_select_0 = false;
        [SerializeField] GameObject select_audio;
        [SerializeField] AnimationClip disappear;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            script_controller = FindObjectOfType<ScriptController>();
            playerui = FindObjectOfType<PlayerUIController>();
            script_controller.onFinish += End;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            select_0 = transform.GetChild(0).gameObject;
        }

        private void Update()
        {
            if (script_controller.text_index == 21 && if_select_0 == false)
            {
                select_0.SetActive(true);
                if_select_0 = true;
            }
        }

        public void Save()
        {
            select_0.GetComponent<Animator>().SetBool("Disappear", true);
            select_audio.GetComponent<AudioSource>().Play();
            Invoke("RestoreSave", disappear.length);
        }

        private void RestoreSave()
        {
            Destroy(select_0);
            script.SetActive(true);
            script_controller.ScriptUpdate(22);
        }

        public void NotSave()
        {
            ReminderController rc = FindObjectOfType<ReminderController>();
            rc.current_index += 1;
            select_0.GetComponent<Animator>().SetBool("Disappear", true);
            select_audio.GetComponent<AudioSource>().Play();
            Invoke("RestoreNotSave", disappear.length);
        }

        private void RestoreNotSave()
        {
            Destroy(select_0);
            script.SetActive(true);
            script_controller.ScriptUpdate(32);
        }

        public void SilverButtonPressed()
        {
            script.SetActive(true);
            script_controller.ScriptUpdate(1);
            playerui.PackageButtonPressed();
        }

        public void YuanbaoButtonPressed()
        {
            script.SetActive(true);
            script_controller.ScriptUpdate(1);
            playerui.PackageButtonPressed();
        }

        public void End(float none)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(14);
        }
    }
}
