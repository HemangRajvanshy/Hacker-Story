﻿using UnityEngine;
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
            Tab.SetActive(false);
            Tab.transform.SetParent(GameManager.Game.Hack.Browser.Tabs.transform);
            Tab.transform.localScale =
            Tab.transform.localScale = GameManager.Game.Hack.Browser.Tabs.transform.localScale;
            Tab.transform.position = GameManager.Game.Hack.Browser.Tabs.transform.position;
            Tab.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
        }
    }
}
