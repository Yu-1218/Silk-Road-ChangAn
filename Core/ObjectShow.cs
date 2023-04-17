using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class ObjectShow : MonoBehaviour
    {
        [SerializeField] GameObject total_object;
        GameObject sprite;

        public void ShowObject()
        {
            total_object.SetActive(true);
            sprite = total_object.transform.GetChild(0).gameObject;
            sprite.GetComponent<Animator>().SetTrigger("Show");
            Invoke("Disappear", 2.5f);
        }

        public void Disappear()
        {
            total_object.GetComponent<Animator>().SetTrigger("Disappear");
            Invoke("DestroyObject", 1.0f);
        }

        public void DestroyObject()
        {
            Destroy(total_object);
        }
    }
}
