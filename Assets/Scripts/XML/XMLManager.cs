using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XMLSystem
{
    public class XMLManager : MonoBehaviour
    {
        [SerializeField] XMLObjectSaver xmlObjectSaver;
        [SerializeField] XMLObjectLoader xmlObjectLoader;
        public SceneLists sceneLists;

        // Hierachy management 
        public Transform spawnedParent;

        #region Singleton
        private static XMLManager _instance;
        public static XMLManager Instance { get { return _instance; } }

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Debug.Log("Two instances of XMLManager are in the scene, Singleton..");
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        public void SaveToXML()
        {
            // Populate XML Object with data.
            XMLScene xmlScene = PopulateXMLScene();
            // Write to XML with data
            FileOperations.WriteXMLFile(xmlScene, Application.dataPath + "/Resources/XMLScene.xml");
        }

        /// <summary>
        /// Builds XMLScene object populated with data from the currently running scene.
        /// </summary>
        /// <returns></returns>
        public XMLScene PopulateXMLScene()
        {
            XMLScene xmlScene = new XMLScene();
            // Populate the SceneLists lists with references of the GameObjects in scene to save.
            sceneLists.PopulateLists();
            // Pull the data from the objects in the lists to the XMLScene object.
            xmlObjectSaver.SaveListOfObjects(ref xmlScene.sceneObjects);
            return xmlScene;
        }

        public void LoadFromXML()
        {
            XMLScene xmlScene = new XMLScene();
            xmlScene = FileOperations.LoadFromXMLFile<XMLScene>(Application.dataPath + "/Resources/XMLScene.xml");

            if (xmlScene != null)
            {
                // Transfer the data.
                xmlObjectLoader.LoadAllObjects(xmlScene, spawnedParent);
            }

        }    
    }
}
