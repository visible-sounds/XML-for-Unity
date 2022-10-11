using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.AddressableAssets;

namespace XMLSystem
{
    public class SceneLists : MonoBehaviour
    {
        private List<GameObject> allGameObjects;
        private List<GameObject> dynamicObjects;

        public List<GameObject> DynamicObjects
        {
            get { return this.dynamicObjects; }
        }

        public void PopulateLists()
        {
            GetAllObjectsInScene();
            FilterLists();
        }

        private void GetAllObjectsInScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            allGameObjects = new List<GameObject>(scene.GetRootGameObjects());
            for (int i = 0; i < allGameObjects.Count; i++)
            {
                if (allGameObjects[i] == null)
                    continue;
                GetRecursiveObjects(allGameObjects[i]);
            }
        }

        private void GetRecursiveObjects(GameObject objToSearch)
        {
            if (objToSearch == null)
                return;
            foreach(Transform child in objToSearch.transform)
            {
                if (null == child)
                    continue;
                allGameObjects.Add(child.gameObject);
                GetRecursiveObjects(child.gameObject);
            }
        }

        private void FilterLists()
        {
            dynamicObjects = new List<GameObject>();
            foreach (GameObject obj in allGameObjects)
            {
                if (obj.tag == "Dynamic")
                {
                    dynamicObjects.Add(obj);
                }
            }
        }

        /// <summary>
        /// Use for objects that are addressable releasing objects using the same memory address.
        /// </summary>
        public void ReleaseAll()
        {
            PopulateLists();
            ReleaseInstances(dynamicObjects);
            DestroyAll(); // Destroy the rest.
        }

        private void DestroyAll()
        {
            DestroyList(dynamicObjects);
        }

        private void DestroyList(List<GameObject> hashSetToClear)
        {
            foreach (GameObject obj in hashSetToClear)
            {
                Destroy(obj);
            }
            hashSetToClear.Clear();
        }

        private void ReleaseInstances(List<GameObject> instancesToRelease)
        {
            if (instancesToRelease != null)
            {
                for (int i = 0; i < instancesToRelease.Count; i++)
                {
                    Addressables.ReleaseInstance(instancesToRelease[i]);
                }
            }
            else
                Debug.LogWarning("Objects not found to release");
        }
    }
}