using UnityEngine;
using System.Collections;

public class SfxManager : MonoBehaviour {

    public bool On { get; private set; }

    void Awake()
    {
        if (Main.Instance.PlayerData != null)
            On = Main.Instance.PlayerData.Sfx;
        else
            On = true; 
    }

    public void MenuOnToggle()
    {
        On = GameObject.Find("Canvas/BackgroundImage").GetComponent<Menu_UI>().SfxToggle.isOn;
    }
}
