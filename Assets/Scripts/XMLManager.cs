using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XMLSystem
{
    public class XMLManager : MonoBehaviour
    {
        [SerializeField] SceneObjectPrefabList prefabList;
        [SerializeField] SceneLists sceneLists;
        [SerializeField] XMLObjectSaver xmlObjectSaver;
        

        public void SaveToXML()
        {
            XMLScene xmlScene = PopulateXMLScene();
            FileOperations.WriteXMLFile(xmlScene, Application.dataPath + "/Resources/XMLScene.xml");
        }

        public XMLScene PopulateXMLScene()
        {
            XMLScene xmlScene = new XMLScene();
            sceneLists.PopulateLists();

            xmlObjectSaver.SaveListOfObjects(ref xmlScene.sceneObjects, true, prefabList);
            return xmlScene; 
        }
    }
}
