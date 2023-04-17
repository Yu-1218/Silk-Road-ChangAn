using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SilkRoad.Core;

namespace SilkRoad.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] float fadeOutTime = 0.5f;
        [SerializeField] float fadeInTime = 0.1f;
        [SerializeField] float fadeWaitTime = 0.3f;
        int sceneToLoad = 1;

        public void SwitchScene(int sceneToLoad)
        {
            StartCoroutine("Transition", sceneToLoad);
        }

        public IEnumerator Transition(int sceneToLoad)
        {
            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);

            yield return SceneManager.LoadSceneAsync(sceneToLoad);

            PersistentSceneRecord persistentSceneRecord = FindObjectOfType<PersistentSceneRecord>();
            persistentSceneRecord.SetIndexOfScene(sceneToLoad);


            yield return new WaitForSeconds(fadeWaitTime);
            yield return fader.FadeIn(fadeInTime);

            Destroy(gameObject, 0.1f);
        }

        public Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;

                return portal;
            }
            return null;
        }
    }
}
