using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLSystem
{
    public class XMLObjectSaver : XMLSaver
    {
        public void SaveListOfObjects(ref List<XMLObject> saveList)
        {
            saveList = new List<XMLObject>();
            
            List<GameObject> listRef = XMLManager.Instance.sceneLists.DynamicObjects;
            for (int i = 0; i < listRef.Count; i++)
            {
                GameObject objToSave = listRef[i];
                saveList.Add(SaveDynamicObject(objToSave));
            }            
        }

        /// <summary>
        /// Create a serializable XMLObject from a GameObject.
        /// </summary>
        /// <param name="objToSave"></param>
        /// <returns></returns>
        public XMLObject SaveDynamicObject(GameObject objToSave)
        {
            // #Tip You can reference additional components here to extract data from and assign it to the assignedObject.

            XMLObject assignedObject = new XMLObject();
            assignedObject.xmlTransform = new XMLTransform();
            assignedObject.xmlTransform.Set(objToSave.transform);
            // Get the unique identifier of the asset and save it to XML.
            assignedObject.assetReference = GetAddressKey(objToSave);

            return assignedObject;
        }
    }
}