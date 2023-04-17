using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using SilkRoad.Core;

namespace SilkRoad.Interact
{
    public class Scene_7_Interact : MonoBehaviour
    {
        GameObject silver;
        bool if_silver = false;
        ScriptController sc;
        GameObject script;
        [SerializeField] GameObject YuanBao;
        bool if_yuanbao = false;

        [SerializeField] GameObject Pearl;
        bool if_pearl = false;

        private void Start()
        {
            silver = transform.GetChild(0).gameObject;
            silver.SetActive(false);
            sc = FindObjectOfType<ScriptController>();
            script = GameObject.FindGameObjectWithTag("Script");
        }

        private void Update()
        {
            if (if_silver == false && sc.text_index == 21)
            {
                silver.SetActive(true);
                if_silver = true;
            }

            if (if_yuanbao == false && sc.text_index == 27)
            {
                YuanBao.SetActive(true);
                if_yuanbao = true;
                YuanBao.GetComponent<ObjectShow>().ShowObject();
            }

            if (if_pearl == false && sc.text_index == 6)
            {
                Pearl.SetActive(true);
                if_pearl = true;
                Pearl.GetComponent<ObjectShow>().ShowObject();
            }
        }

        public void SilverButtonPressed()
        {
            Destroy(silver);
            script.SetActive(true);
            sc.ScriptUpdate(1);
        }
    }
}
