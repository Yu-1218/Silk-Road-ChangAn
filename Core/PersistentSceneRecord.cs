using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilkRoad.Core
{
    public class PersistentSceneRecord : MonoBehaviour
    {
        public int indexOfScene = 0;

        public int GetIndexOfScene()
        {
            return indexOfScene;
        }

        public void AddIndexOfScene()
        {
            indexOfScene += 1;
        }

        public void SetIndexOfScene(int newIndex)
        {
            indexOfScene = newIndex;
        }
    }
}
