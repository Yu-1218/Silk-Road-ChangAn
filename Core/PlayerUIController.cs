using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.SceneManagement;

namespace SilkRoad.Core
{
    public class PlayerUIController : MonoBehaviour
    {
        GameObject package;
        bool package_show = false;
        float wait_time = 0.01f;
        [SerializeField] int maxX, minX, moveForce;
        [SerializeField] int map_index;
        Portal portal;


        private void Start()
        {
            package = transform.GetChild(4).gameObject;
            portal = FindObjectOfType<Portal>().GetOtherPortal();
        }

        public void PackageButtonPressed()
        {
            if (package_show == false)
            {
                StartCoroutine("ShowPackage");
                package_show = true;
            }
            else
            {
                StartCoroutine("RevertPackage");
                package_show = false;
            }
        }

        public void MapButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(map_index);
        }

        IEnumerator ShowPackage()
        {
            while (package.transform.localPosition.x > minX)
            {
                Vector2 vec = package.transform.localPosition;
                vec.x -= Time.deltaTime * moveForce;
                package.transform.localPosition = vec;
                yield return new WaitForSeconds(wait_time);
            }
        }

        IEnumerator RevertPackage()
        {
            while (package.transform.localPosition.x < maxX)
            {
                Vector2 vec = package.transform.localPosition;
                vec.x += Time.deltaTime * moveForce;
                package.transform.localPosition = vec;
                yield return new WaitForSeconds(wait_time);
            }
        }
    }
}
