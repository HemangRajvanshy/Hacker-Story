using UnityEngine;
using System.Collections;

public class Desktop : MonoBehaviour {

    //Panel objects
    public App HackerGuide;
    public App Browser;
    public App Computer;

    public TaskBar TaskBar;

    //[HideInInspector]
    //private DesktopState state;
    //public enum DesktopState
    //{
    //    Desktop,
    //    HackerGuide,
    //    Computer, 
    //    Browser
    //};

    void Start()
    {
        //ShowDesktop();
    }

    public void ShowHackerGuide()
    {
      //  state = DesktopState.HackerGuide;
        OpenApplication(HackerGuide);
    }

    public void ShowBrowser()
    {
      //  state = DesktopState.Browser;
        OpenApplication(Browser);
    }

    public void ShowComputer()
    {
       // state = DesktopState.Computer;
        OpenApplication(Computer);
    }

    private void OpenApplication(App App)
    {
        App.Open();
        TaskBar.OpenApplication(App);
    }

    public void MinimizeApplication(App App)
    {
        App.Minimize();
        TaskBar.MinimizeApplication(App);
    }

    public void CloseApplication(App App)
    {
        if (App.open)
        {
            App.Close();
            TaskBar.CloseApplication(App); 
        }
    }
}
