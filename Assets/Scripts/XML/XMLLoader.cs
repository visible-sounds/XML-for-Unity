using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class XMLLoader : MonoBehaviour
{
    protected GameObject InstantiateAddressable(string key, Transform parent)
    {
        try
        {
            return Addressables.InstantiateAsync(key, parent).WaitForCompletion();
        }
        catch(Exception e)
        {
            Debug.LogWarning(key + "\n" + "(Object not loaded) Exception: " + e);
            return null;
        }
    }
}
