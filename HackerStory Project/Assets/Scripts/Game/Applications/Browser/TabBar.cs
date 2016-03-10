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
        if(OpenApps.Count == 0)
        {
            GameManager.Game.Hack.Desktop.CloseApplication(GameManager.Game.Hack.Desktop.Browser);
        }
    }
}
