using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SilkRoad.SceneManagement;

namespace SilkRoad.Map
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] Camera main_camera;
        Portal portal;

        private void Update()
        {
            main_camera.orthographicSize = (float)(2.3 * slider.value + 5);
            portal = FindObjectOfType<Portal>();
        }

        public void CaoTipButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(10);
        }

        public void YongJiaHangButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(9);
        }

        public void KouMaShiButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(13);
        }

        public void JiaoFangButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(15);
        }

        public void DaCiEnSiButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(21);
        }

        public void ShengSiYuanButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(24);
        }

        public void GuiYuanSiButtonPressed()
        {
            portal = FindObjectOfType<Portal>();
            portal.SwitchScene(25);
        }

    }
}
