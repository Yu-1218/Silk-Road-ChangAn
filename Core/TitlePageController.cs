using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class TitlePageController : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        float time = 2f;

        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            Invoke("TitleFaded", 3);
        }

        // Update is called once per frame
        void TitleFaded()
        {
            StartCoroutine("FadeIn");
        }

        public IEnumerator FadeIn()
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
