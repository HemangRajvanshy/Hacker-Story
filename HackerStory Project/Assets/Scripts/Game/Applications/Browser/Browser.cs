using UnityEngine;
using System.Collections;

public class Browser : App {

    public TabBar TabBar;
    public Tab HomeTab;
    public Tab NotFoundTab;
    public GameObject Tabs;

    protected override void Start()
    {
        OpenTab(HomeTab); 
    }

    public void OpenTab(Tab tab)
    {
        tab.Open(); 
        TabBar.OpenApplication(tab);
    }

    public void OpenInSameTab(Tab tab)
    {
        tab.Open();
        TabBar.OpenInSameTab(tab);
    }

    public void CloseTab(App app)
    {
        app.Close();
        TabBar.CloseApplication(app);
    }

    public void PageNotFound()
    {
        OpenInSameTab(NotFoundTab);
    }

    public override void Close()
    {
        if(open)
            OpenTab(HomeTab); // Enable HomeTab so that it opens up when you start it again.
        base.Close();
    }
}
