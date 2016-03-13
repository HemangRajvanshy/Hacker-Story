using UnityEngine;
using System.Collections;

public class SchoolSiteTab : Tab {

	public void OnSourceView()
    {
        var browser = GameManager.Game.Hack.Browser;
        browser.Omni.SetAddressAndOpen ("view-source:www.SchoolSite.com", false);
    }
}
