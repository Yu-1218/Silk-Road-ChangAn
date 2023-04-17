using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace SilkRoad.Video
{
    public class GameStartController : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayer player;

        [SerializeField]
        private GameObject startButton;

        private void Start()
        {
            startButton.SetActive(false);
            player.loopPointReached += CheckOver;
        }

        public void SkipAnimation()
        {
            player.frame = 1620;
            startButton.SetActive(true);
        }

        void CheckOver(VideoPlayer vp)
        {
            startButton.SetActive(true);
        }
    }
}

