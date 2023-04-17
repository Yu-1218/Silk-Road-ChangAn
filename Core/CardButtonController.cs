using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class CardButtonController : MonoBehaviour
    {
        [SerializeField] GameObject card;

        public void OpenCard()
        {
            GameObject player_ui = GameObject.FindGameObjectWithTag("Player UI");
            Instantiate(card, player_ui.transform);
        }
    }
}
