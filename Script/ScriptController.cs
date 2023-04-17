using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using SilkRoad.Core;

namespace SilkRoad.Script
{
    public class ScriptController : MonoBehaviour
    {
        [SerializeField] string raw_portraits;
        [SerializeField] string script_name;
        GameObject portrait;
        string[] portrait_array;
        List<Sprite> sprite_array = new List<Sprite>();
        GameObject text;
        TextMeshProUGUI text_content;
        string[] raw_text_array;
        List<string> text_array = new List<string>();
        List<int> text_of_portrait = new List<int>();
        public int text_index = 0;
        float waitTime = 0.05f;
        ControlSetter player_control_setter;
        public event Action<float> onFinish;
        bool is_Delayed = false;


        private void Start()
        {
            InitPortrait();
            InitText();
            player_control_setter = FindObjectOfType<ControlSetter>();
            DisablePlayer();
        }

        private void Update()
        {
            if (!is_Delayed)
            {
                Delay();
                is_Delayed = true;
            }
        }

        void Delay()
        {
            gameObject.SetActive(false);
            Invoke("ShowScript", 1.5f);
        }

        void ShowScript()
        {
            gameObject.SetActive(true);
        }

        private void DisablePlayer()
        {
            player_control_setter.DisablePlayerControl();
        }

        private void InitPortrait()
        {
            portrait_array = raw_portraits.Split(", ");
            portrait = transform.GetChild(0).gameObject;
            for (int i = 0; i < portrait_array.Length; i++)
            {
                string path = "Portraits/" + portrait_array[i];
                sprite_array.Add(Resources.Load<Sprite>(path));
            }
            SwitchPortrait(0);
        }

        private void InitText()
        {
            text = transform.GetChild(1).gameObject;
            text_content = text.GetComponent<TextMeshProUGUI>();

            string script_path = "Scripts/" + script_name;
            var raw_text = Resources.Load<TextAsset>(script_path).text;
            raw_text_array = raw_text.Split("\n");

            for (int i = 0; i < raw_text_array.Length; i++)
            {
                if (raw_text_array[i].Length == 1)
                {
                    text_of_portrait.Add(-1);
                    text_array.Add("");
                    continue;
                }
                else
                {
                    int tmp = (int)Char.GetNumericValue(raw_text_array[i][0]);
                    text_of_portrait.Add(tmp);
                    text_array.Add(raw_text_array[i].Substring(2, raw_text_array[i].Length - 3));
                }
            }
            text_content.text = text_array[0];
            SwitchPortrait(text_of_portrait[0]);
        }


        public void SwitchPortrait(int index)
        {
            portrait.GetComponent<Image>().sprite = sprite_array[index];
        }

        public void ButtonPressed()
        {
            ScriptUpdate(1);

        }

        public void ScriptUpdate(int offset)
        {
            player_control_setter = FindObjectOfType<ControlSetter>();
            player_control_setter.DisablePlayerControl();
            // Index Update
            if (offset == 1)
            {
                text_index += offset;
            }
            else if (offset > 1)
            {
                text_index = offset;
            }
            // Text Update
            if (text_index == raw_text_array.Length)
            {
                player_control_setter.EnablePlayerControl();
                gameObject.SetActive(false);
                if (onFinish != null)
                {
                    onFinish(0);
                }
            }
            else if (raw_text_array[text_index].Length == 1)
            {
                player_control_setter.EnablePlayerControl();
                gameObject.SetActive(false);
            }
            else if (text_of_portrait[text_index] == 9)
            {
                text_index = int.Parse(text_array[text_index]);
                SwitchPortrait(text_of_portrait[text_index]);
                StopCoroutine("SwitchText");
                StartCoroutine("SwitchText");
            }
            else
            {
                SwitchPortrait(text_of_portrait[text_index]);
                StopCoroutine("SwitchText");
                StartCoroutine("SwitchText");
            }
        }

        IEnumerator SwitchText()
        {
            text_content.text = "";
            foreach (char c in text_array[text_index])
            {
                text_content.text += c;
                yield return new WaitForSeconds(waitTime);
            }
        }

    }
}
