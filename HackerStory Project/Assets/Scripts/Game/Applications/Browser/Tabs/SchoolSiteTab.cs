using UnityEngine;
using System.Collections;

public class SchoolSiteTab : Tab {

	public void OnSourceView()
    {
        var browser = GameManager.Game.Hack.Browser;
        browser.OpenTab( browser.Tabs.transform.FindChild("SchoolSiteSource").GetComponent<Tab>() , "view-source:www.SchoolSite.com");
    }
}
