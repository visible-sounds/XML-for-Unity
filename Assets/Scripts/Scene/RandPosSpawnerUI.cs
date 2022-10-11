using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandPosSpawnerUI : MonoBehaviour
{
    [SerializeField] GameObject propertiesPanel;
    [SerializeField] RandPosSpawner randPosSpawner;
    [SerializeField] TMP_InputField amountInput;
    [SerializeField] int returnedString;


    private void Start()
    {
        amountInput.onEndEdit.AddListener((string s)=>ReturnInput(s));    
    } 

    public void TogglePanel()
    {
        propertiesPanel.SetActive(!propertiesPanel.activeInHierarchy);
    }

    public void OnRunSpawner()
    {
        randPosSpawner.SpawnRandomAssets(returnedString);
    }

    
    public string ReturnInput(string s)
    {
        if (!string.IsNullOrEmpty(s))
        {
            returnedString =  int.Parse(s);
            return s;
        }
        else
            return "";
    }
}
