﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabBar : TaskBar {

    public Browser Browser;

    public override void CloseApplication(App app)
    {
        base.CloseApplication(app);
        if(OpenApps.Count == 0)
        {
            GameManager.Game.Hack.Desktop.CloseApplication(GameManager.Game.Hack.Desktop.Browser);
        }
    }
}
