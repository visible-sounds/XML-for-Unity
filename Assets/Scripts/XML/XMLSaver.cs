using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace XMLSystem
{
    public class XMLSaver : MonoBehaviour
    {
        /// <summary>
        /// Returns the string of the RuntimeKey from the AssetReference assigned to the prefab.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetAddressKey(GameObject obj)
        {
            // Get the assetRef from the GameObject in scene.
            AssetReference assetRef = obj.GetComponent<XMLPrefabID>().addressableAsset;

            // Check whether the key is valid.
            if (assetRef.RuntimeKeyIsValid())
            {
                return obj.GetComponent<XMLPrefabID>().addressableAsset.RuntimeKey.ToString();
            }
            else
            {
                Debug.LogWarning("! AssetRef on " + obj.name + " is null");
                return null;
            }
        }
    }
}
