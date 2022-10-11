using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class RandPosSpawner : MonoBehaviour
{
    [SerializeField] private List<AssetReference> assets = new List<AssetReference>();
    [SerializeField] private GameObject areaObject;

    public void SpawnRandomAssets(int amountToSpawn)
    {
        Bounds bounds = areaObject.GetComponent<Collider>().bounds;
        for (int i = 0; i < amountToSpawn; i++)
        {
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
            float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

            GameObject newRandomObj = Addressables.InstantiateAsync(assets[Random.Range(0, assets.Count)]).WaitForCompletion();
            newRandomObj.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
            newRandomObj.transform.rotation = Quaternion.Euler(Random.Range(-bounds.extents.x, bounds.extents.x), Random.Range(-bounds.extents.y, bounds.extents.y), Random.Range(-bounds.extents.x, bounds.extents.x));
        }
    }
}
