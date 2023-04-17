using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;
using SilkRoad.SceneManagement;

namespace SilkRoad.Interact
{
    public class Scene_2_Interact : MonoBehaviour
    {
        GameObject JinZhuo;
        GameObject Blanket;
        GameObject Notebook;
        GameObject Script;
        GameObject NotebookAnim;
        [SerializeField] AnimationClip note_anim;
        Portal portal;
        [SerializeField] GameObject note_audio;


        private void Start()
        {
            JinZhuo = transform.GetChild(0).gameObject;
            Blanket = transform.GetChild(1).gameObject;
            Notebook = transform.GetChild(2).gameObject;
            Script = GameObject.FindGameObjectWithTag("Script");
            NotebookAnim = GameObject.FindGameObjectWithTag("Full Screen Anim");
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            NotebookAnim.SetActive(false);
            Script.GetComponent<ScriptController>().onFinish += End;
        }

        public void YuanBaoButtonPressed()
        {
            Destroy(JinZhuo);
            Script.SetActive(true);
            Script.GetComponent<ScriptController>().ScriptUpdate(10);
        }

        public void BlanketButtonPressed()
        {
            Destroy(Blanket);
            Script.SetActive(true);
            Script.GetComponent<ScriptController>().ScriptUpdate(12);
        }

        public void NotebookButtonPressed()
        {
            Destroy(Notebook);
            Script.SetActive(true);
            Script.GetComponent<ScriptController>().ScriptUpdate(14);
        }

        IEnumerator NotebookTransition()
        {
            portal = FindObjectOfType<Portal>();
            NotebookAnim.SetActive(true);
            note_audio.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(note_anim.length);
            portal.SwitchScene(3);
        }

        public void End(float none)
        {
            StartCoroutine("NotebookTransition");
        }
    }
}
