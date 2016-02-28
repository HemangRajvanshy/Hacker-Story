using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public bool On { get; private set; }

    void Awake()
    {
        if (Main.Instance.player.PlayerDataExists)
            On = Main.Instance.player.PlayerData.Music;
        else
            On = true;
    }

    public void MenuOnToggle()
    {
        On = GameObject.Find("Canvas/BackgroundImage").GetComponent<Menu_UI>().MusicToggle.isOn;
    }
}
