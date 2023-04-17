using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Core;

namespace SilkRoad.SceneManagement
{
    public class ChapterAnimationController : MonoBehaviour
    {
        Portal portal;
        Animator animator;
        AnimatorStateInfo animStateInfo;
        bool animationFinished = false;
        void Start()
        {
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            animStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (animationFinished == false && animStateInfo.normalizedTime > 1)
            {
                LoadNextScene();
                animationFinished = true;
            }
        }

        void LoadNextScene()
        {
            PersistentSceneRecord record = FindObjectOfType<PersistentSceneRecord>();
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(record.GetIndexOfScene() + 1);
        }


    }

}
