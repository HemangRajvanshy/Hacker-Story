using UnityEngine;
using System.Collections;

public class Browser : App {

    public OmniBox Omni;
    public TabBar TabBar;
    public Tab HomeTab;
    public Tab NotFoundTab;
    public GameObject Tabs;

    protected override void Start()
    {
        OpenTab(HomeTab); 
    }

    public void OpenTab(Tab tab, string Address = "")
    {
        tab.Open(); 
        TabBar.OpenApplication(tab);
        Omni.SetAddress(Address);
    }

    public void OpenInSameTab(Tab tab, string Address = "")
    {
        tab.Open();
        TabBar.OpenInSameTab(tab);
        Omni.SetAddress(Address);
    }

    public void CloseTab(App app)
    {
        app.Close();
        TabBar.CloseApplication(app);
    }

    public void PageNotFound(string address)
    {
        OpenInSameTab(NotFoundTab, address);
    }

    public override void Close()
    {
        TabBar.CloseAllTabs();
        if (open)
        {
            OpenTab(HomeTab); // Enable HomeTab so that it opens up when you start it again.
        }
        base.Close();
    }
}
