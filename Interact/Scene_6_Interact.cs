using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.SceneManagement;
using SilkRoad.Core;

namespace SilkRoad.Interact
{
    public class Scene_6_Interact : MonoBehaviour
    {
        [SerializeField] GameObject wine;
        [SerializeField] GameObject wine_button;
        [SerializeField] GameObject jinzhuo;
        GameObject script;
        ScriptController script_controller;
        bool if_wine = false;
        [SerializeField] AnimationClip wine_anim;
        Portal portal;
        PlayerUIController playerui;
        GameObject NotebookAnim;
        [SerializeField] AnimationClip note_anim;
        [SerializeField] GameObject note_audio;

        private void Start()
        {
            wine.GetComponent<Animator>().enabled = false;
            wine_button.SetActive(false);
            script = GameObject.FindGameObjectWithTag("Script");
            script_controller = FindObjectOfType<ScriptController>();
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            playerui = FindObjectOfType<PlayerUIController>();
            NotebookAnim = GameObject.FindGameObjectWithTag("Full Screen Anim");
            NotebookAnim.SetActive(false);
        }

        private void Update()
        {
            if (if_wine == false && script_controller.text_index == 2)
            {
                if_wine = true;
                wine_button.SetActive(true);
            }
        }

        public void WineButtionPressed()
        {
            wine.GetComponent<Animator>().enabled = true;
            Destroy(wine_button);
            StartCoroutine("WineTransition");
        }

        public void JinZhuoButtonPressed()
        {
            Destroy(jinzhuo);
            script.SetActive(true);
            script_controller.ScriptUpdate(1);
            playerui.PackageButtonPressed();
        }

        IEnumerator WineTransition()
        {
            yield return new WaitForSeconds(wine_anim.length);
            script.SetActive(true);
            script_controller.ScriptUpdate(1);
        }

        public void NotebookButtonPressed()
        {
            StopCoroutine("NotebookTransition");
            StartCoroutine("NotebookTransition");
        }

        IEnumerator NotebookTransition()
        {
            portal = FindObjectOfType<Portal>();
            NotebookAnim.SetActive(true);
            note_audio.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(note_anim.length);
            portal.SwitchScene(7);
        }
    }
}
