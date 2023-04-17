using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Audio
{
    public class PlaySound : MonoBehaviour
    {
        public void Play()
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
