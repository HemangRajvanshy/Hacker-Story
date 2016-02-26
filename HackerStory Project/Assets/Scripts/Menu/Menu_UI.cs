using UnityEngine;
using System.Collections;

public class Menu_UI : MonoBehaviour {

    public GameObject PlayPanel;
    public GameObject CreditsPanel;
    
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
