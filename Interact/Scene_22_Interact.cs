using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.SceneManagement;
using SilkRoad.Script;

namespace SilkRoad.Interact
{
    public class Scene_22_Interact : MonoBehaviour
    {
        GameObject script;
        Portal portal;
        GameObject NotebookAnim;
        [SerializeField] AnimationClip note_anim;
        [SerializeField] GameObject note_audio;

        private void Start()
        {
            script = GameObject.FindGameObjectWithTag("Script");
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            NotebookAnim = GameObject.FindGameObjectWithTag("Full Screen Anim");
            NotebookAnim.SetActive(false);
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
            portal.SwitchScene(23);
        }

    }
}
