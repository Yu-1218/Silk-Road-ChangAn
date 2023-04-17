using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class CameraFollow : MonoBehaviour
    {
        private GameObject player;
        private Vector3 tmp;

        [SerializeField]
        float minX, maxX;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            tmp = transform.position;
            tmp.x = player.transform.position.x;
            if (tmp.x < minX)
            {
                tmp.x = minX;
            }

            if (tmp.x > maxX)
            {
                tmp.x = maxX;
            }
            transform.position = tmp;
        }
    }
}
