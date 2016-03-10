using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Hack : MonoBehaviour {

    public List<string> TabAddress;
    public List<GameObject> Tabs;

    public Canvas HackCanvas;

    void Start()
    {
        HackCanvas.worldCamera = Camera.main;
        foreach(GameObject Tab in Tabs)
        {
            Tab.transform.SetParent(GameManager.Game.Hack.Browser.Tabs.transform);
        }
    }
}
