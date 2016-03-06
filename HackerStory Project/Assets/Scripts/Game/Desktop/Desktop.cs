using UnityEngine;
using System.Collections;

public class Desktop : MonoBehaviour {

    //Panel objects
    public App HackerGuide;
    public App Browser;
    public App Computer;

    public TaskBar TaskBar;

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
        HackerGuide.Close();
        Browser.Close();
        Computer.Close();
    }

    private void OpenApplication(App App)
    {
        App.Open();
    }

    public void MinimizeApplication(App App)
    {
        App.Minimize(); //TODO
    }

    public void CloseApplication(App App)
    {
        App.Close(); //TODO
    }
}
