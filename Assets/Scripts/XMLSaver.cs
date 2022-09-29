using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLSystem
{
    public class XMLSaver : MonoBehaviour
    {
        protected string GetPrefabID(GameObject obj)
        {
            return obj.GetComponent<XMLPrefabID>().prefabID;
        }
    }
}
