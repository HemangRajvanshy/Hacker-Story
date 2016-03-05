using UnityEngine;
using System.Collections;

public class Desktop : MonoBehaviour {

    public GameObject HackerGuide;
    public GameObject Browser;
    public GameObject Computer;

    private DesktopState state;
    private enum DesktopState
    {
        Desktop,
        HackerGuide,
        Computer, 
        Browser
    };

    void Start()
    {
        ShowDesktop();
    }

    public void ShowHackerGuide()
    {
        state = DesktopState.HackerGuide;
        OpenApplication(HackerGuide);
    }

    public void ShowBrowser()
    {
        state = DesktopState.Browser;
        OpenApplication(Browser);
    }

    public void ShowComputer()
    {
        state = DesktopState.Computer;
        OpenApplication(Computer);
    }

    public void ShowDesktop()
    {
        state = DesktopState.Desktop;
        HackerGuide.SetActive(false);
        Browser.SetActive(false);
        Computer.SetActive(false);
    }

    private void OpenApplication(GameObject App)
    {
        App.SetActive(true);
    }

    public void MinimizeApplication(GameObject App)
    {
        App.SetActive(false); //TODO
    }

    public void CloseApplication(GameObject App)
    {
        App.SetActive(false); //TODO
    }
}
