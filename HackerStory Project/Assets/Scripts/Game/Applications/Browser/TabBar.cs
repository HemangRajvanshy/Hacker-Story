using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabBar : TaskBar {

    public Browser Browser;

    protected override void Start()
    {
        base.Start();
    }

    public void OpenInSameTab(Tab tab)
    {
        OpenApplication(tab);
        foreach(App app in OpenApps.Keys)
        {
            if (app.open && app != tab)
            {
                Browser.CloseTab(app);
                break;
            }
        }
    }

    public override void CloseApplication(App app)
    {
        base.CloseApplication(app);
        if(OpenApps.Count == 0 && GameManager.Game.Hack.Desktop.Browser.open)
        {
            GameManager.Game.Hack.Desktop.CloseApplication(GameManager.Game.Hack.Desktop.Browser);
        }
    }

    public void CloseAllTabs()
    {
        var TempList = new System.Collections.Generic.List<App>(OpenApps.Keys);
        foreach (App app in TempList)
        {
            if (app.open)
            {
                if (app.name != "HomeTab")
                    Browser.CloseTab(app);
            }   
        }
    }
}
