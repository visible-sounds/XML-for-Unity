using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesUtil : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        AsyncOperationHandle<IResourceLocator> handle = Addressables.InitializeAsync();
        yield return handle;
    }

    public static bool AssetExists(string key)
    {
        if (Application.isPlaying)
        {
            foreach (IResourceLocator irl in Addressables.ResourceLocators)
            {
                IList<IResourceLocation> locs;
                if (irl.Locate(key, null, out locs))
                    return true;
            }
            return false;
        }
        else
            return false;
    }
}
