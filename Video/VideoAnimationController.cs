using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using SilkRoad.SceneManagement;

namespace SilkRoad.Video
{
    public class VideoAnimationController : MonoBehaviour
    {
        [SerializeField] VideoPlayer player;
        [SerializeField] int scene_to_load;
        Portal portal;


        private void Start()
        {
            portal = FindObjectOfType<Portal>().GetOtherPortal();
            player.loopPointReached += CheckOver;
        }

        void CheckOver(VideoPlayer vp)
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(scene_to_load);
        }
    }
}
