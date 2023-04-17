using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class CardController : MonoBehaviour
    {
        public void CloseCard()
        {
            Destroy(gameObject);
        }
    }
}
