using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;


namespace XMLSystem
{

    /// <summary>
    /// Custom editor class to assign a unique ID to the prefab and update the prefabs in the file system.
    /// </summary>
    [InitializeOnLoad]
    public class XMLPrefabIDGenerator : Editor
    {
        public int callbackOrder { get { return 0; } }

        [UnityEditor.MenuItem("XML/Generate Prefab ID's")]
        private static void GeneratePrefabIDs()
        {
            string[] guidList = AssetDatabase.FindAssets("t:GameObject", new[] { "Assets/Prefabs" });

            for (int i = 0; i < guidList.Length; i++)
            {
                string objectPath = AssetDatabase.GUIDToAssetPath(guidList[i]);
                GameObject obj = (GameObject)AssetDatabase.LoadAssetAtPath(objectPath, typeof(GameObject));

                if (obj.TryGetComponent(out XMLPrefabID iDComponent))
                {
                    iDComponent.prefabID = guidList[i];
                    PrefabUtility.SavePrefabAsset(obj);
                }
                else
                {
                    Debug.Log("This (" + obj.name+ ") doesn't have a prefab ID component");
                    obj = null;
                }
            }
            guidList = null;
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            Debug.Log("Generating pre process build prefab ID's");
            GeneratePrefabIDs();
        }
    }
}

