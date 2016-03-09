using UnityEngine;
using System.Collections;

public class Browser : App {

    public TabBar TabBar;
    public Tab HomeTab;

    protected override void Start()
    {
        OpenTab(HomeTab);
    }

    public void OpenTab(Tab tab)
    {
        tab.Open();
        TabBar.OpenApplication(tab);
    }

    public void CloseTab(App app)
    {
        app.Close();
        TabBar.CloseApplication(app);
    }

    public override void Close()
    {
        base.Close();
        OpenTab(HomeTab); // Enable HomeTab so that it opens up when you start it again.
    }
}
