using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLSystem
{
    public class XMLObjectLoader : XMLLoader
    {
        private List<GameObject> previousParents = new List<GameObject>();
        public void LoadAllObjects(XMLScene xmlToLoadFrom, Transform parent)
        {
            // Hierachy Organisation.
            foreach (GameObject subP in previousParents)
            {
                Destroy(subP);
            }
            GameObject subParent = new GameObject();
            subParent.transform.SetParent(parent);
            subParent.name = "Sub";
            previousParents.Add(subParent);

            // Loop through each object in the XML.
            for (int i = 0; i < xmlToLoadFrom.sceneObjects.Count; i++)
            {
                LoadSingleObject(xmlToLoadFrom.sceneObjects[i], subParent.transform);
            }
        }

        public void LoadSingleObject(XMLObject xmlObjToLoad, Transform parent)
        {
            GameObject newObj = InstantiateAddressable(xmlObjToLoad.assetReference, parent);
            xmlObjToLoad.xmlTransform.LoadTransform(newObj.transform);
        }
    }
}
