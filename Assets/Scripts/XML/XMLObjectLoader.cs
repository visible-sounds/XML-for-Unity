using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLSystem
{
    public class XMLObjectLoader : XMLLoader
    {
        public void LoadAllObjects(XMLScene xmlToLoadFrom, Transform parent)
        {
            // Loop through each object in the XML.
            GameObject subParent = Instantiate(new GameObject(), parent);

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
