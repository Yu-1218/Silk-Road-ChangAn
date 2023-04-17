using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilkRoad.Script;
using TMPro;

namespace SilkRoad.Core
{
    public class ReminderController : MonoBehaviour
    {
        [SerializeField] string raw_index;
        [SerializeField] string raw_content;
        List<int> remind_index = new List<int>();
        string[] remind_content;
        public int current_index = 0;
        bool if_remind = true;
        GameObject script;
        TextMeshProUGUI text_content;

        private void Start()
        {
            InitReminder();
            script = GameObject.FindGameObjectWithTag("Script");
        }

        private void Update()
        {
            if (if_remind && script.GetComponent<ScriptController>().text_index == remind_index[current_index])
            {
                if (current_index == 0)
                {
                    text_content.text = remind_content[current_index];
                    gameObject.GetComponent<Animator>().SetTrigger("Enter");
                    Invoke("ReminderDisappear", 4);
                }
                else
                {
                    text_content.text = remind_content[current_index];
                    gameObject.GetComponent<Animator>().SetBool("Disappear", false);
                    Invoke("ReminderDisappear", 4);
                }

                if (current_index == remind_content.Length - 1)
                {
                    if_remind = false;
                }
                else
                {
                    current_index += 1;
                }
            }
        }

        void ReminderDisappear()
        {
            gameObject.GetComponent<Animator>().SetBool("Disappear", true);
        }

        void InitReminder()
        {
            // index
            string[] tmp_index = raw_index.Split(", ");
            for (int i = 0; i < tmp_index.Length; i++)
            {
                remind_index.Add(int.Parse(tmp_index[i]));
            }
            // content
            remind_content = raw_content.Split(", ");
            text_content = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

    }
}
