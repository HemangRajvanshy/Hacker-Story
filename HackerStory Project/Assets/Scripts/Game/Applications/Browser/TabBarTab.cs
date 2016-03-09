using UnityEngine;
using System.Collections;

public class TabBarTab : TaskBarApp {

    public TabBar TabBar;

	public void Quit()
    {
        TabBar.Browser.CloseTab(app);        
    }

    public override void OnClick()
    {
        if (app.transform.parent.childCount > 1)
        {
            if (app.open && app.transform.GetSiblingIndex() == (app.transform.parent.childCount - 1)) // If app is open and is the Last Sibling, ie, Displayed on Screen.
                app.Minimize();
            else
                app.Open(); 
        }
    }
}
