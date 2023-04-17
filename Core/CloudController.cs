using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class CloudController : MonoBehaviour
    {
        [SerializeField] int direction = 1;
        [SerializeField] float speed = 0.5f;

        private void Update()
        {
            Vector2 vec = transform.position;
            vec.x += direction * Time.deltaTime * speed;
            transform.position = vec;
        }
    }
}
