using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPrefabList", menuName = "XML/Prefab List", order = 0)]
public class SceneObjectPrefabList : ScriptableObject
{
    [SerializeField]
    private List<GameObject> prefabList = new List<GameObject>();
    public List<GameObject> PrefabList
    {
        get { return this.prefabList; }
        private set { }
    }
}
