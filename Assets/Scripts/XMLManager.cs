using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XMLSystem
{
    public class XMLManager : MonoBehaviour
    {
        [SerializeField] SceneObjectPrefabList prefabList;
        [SerializeField] SceneLists sceneLists;


        public void SaveToXML()
        {
            XMLScene xmlScene = PopulateXMLScene();

        }

        public XMLScene PopulateXMLScene()
        {
            XMLScene xmlScene = new XMLScene();
            sceneLists.PopulateHashSets();

            return xmlScene; // TODO:
        }
    }
}
