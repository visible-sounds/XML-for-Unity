using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLSystem
{
    public class XMLObjectSaver : XMLSaver
    {
        [SerializeField] SceneLists sceneLists;
        public void SaveListOfObjects(ref List<XMLObject> savedList, bool overwrite, SceneObjectPrefabList prefabList)
        {
            List<XMLObject> _tempList = new List<XMLObject>();
            if (overwrite)
            {
                savedList = new List<XMLObject>();
            }
            for (int i = 0; i < sceneLists.DynamicObjects.Count; i++)
            {
                GameObject objToSave = sceneLists.DynamicObjects[i];
                _tempList.Add(SaveDynamicObject(objToSave));
            }
        }

        public XMLObject SaveDynamicObject(GameObject objToSave)
        {
            XMLObject assignedObject = new XMLObject();

            assignedObject.xmlTransform = new XMLTransform(objToSave.transform);

            assignedObject.prefabID = GetPrefabID(objToSave);

            return assignedObject;
        }
    }
}