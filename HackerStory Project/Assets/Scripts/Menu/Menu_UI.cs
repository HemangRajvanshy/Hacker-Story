using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu_UI : MonoBehaviour {

    public GameObject PlayPanel;
    public GameObject CreditsPanel;

    public Toggle SfxToggle;
    public Toggle MusicToggle;

    void Start()
    {
        SfxToggle.isOn = Main.Instance.SfxMgr.On;
        MusicToggle.isOn = Main.Instance.MusicMgr.On;
    }

    public void ShowCredits()
    {
        PlayPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        PlayPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
}
