using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public bool On { get; private set; }

    void Awake()
    {
        if (Main.Instance.PlayerData != null)
            On = Main.Instance.PlayerData.Music;
        else
            On = true;
    }

    public void MenuToggle(bool value)
    {
        On = value;
    }
}
