using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace XMLSystem
{
    public class SceneLists
    {
        private HashSet<GameObject> allGameObjects = new HashSet<GameObject>();
        private HashSet<GameObject> dynamicObjects = new HashSet<GameObject>();

        public HashSet<GameObject> DynamicObjects
        {
            get { return this.dynamicObjects; }
        }

        public void PopulateHashSets()
        {
            GetAllObjectsInScene();
            FilterHashSets();
        }

        private void GetAllObjectsInScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            allGameObjects = new HashSet<GameObject>(scene.GetRootGameObjects());
            foreach (GameObject obj in allGameObjects)
            {
                if (obj == null)
                    continue;
                GetRecursiveObjects(obj);
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

        private void FilterHashSets()
        {
            foreach (GameObject obj in allGameObjects)
            {
                if (obj.tag == "Dynamic")
                {
                    dynamicObjects.Add(obj);
                }
            }
        }

        public void DestroyAllHashSets()
        {
            DestroyHashSet(dynamicObjects);
            DestroyHashSet(allGameObjects);
        }

        private void DestroyHashSet(HashSet<GameObject> hashSetToClear)
        {
            foreach (GameObject obj in hashSetToClear)
            {
                obj.tag = "Deleted";
                GameObject.Destroy(obj);
            }
            hashSetToClear.Clear();
        }
    }
}