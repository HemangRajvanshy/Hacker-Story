using UnityEngine;
using System.Collections;

public class SfxManager : MonoBehaviour {

    public bool On { get; private set; }
    public AudioSource Audio;

    public AudioClip TypingSfx;

    void Awake()
    {
        if (Main.Instance.PlayerData != null)
            On = Main.Instance.PlayerData.Sfx;
        else
            On = true; 
    }

    public void Play(AudioClip clip)
    {
        Audio.PlayOneShot(clip);
    }

    public void MenuOnToggle()
    {
        On = GameObject.Find("Canvas/BackgroundImage").GetComponent<Menu_UI>().SfxToggle.isOn;
    }
}
