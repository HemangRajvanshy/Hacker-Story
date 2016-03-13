using UnityEngine;
using System.Collections;

public class Tab : App {

    public string Address;

    protected override void Start()
    {
        //Do Nothing. Not the stuff in App.cs, it will give me a nullreference
    }

    public override void Open()
    {
        base.Open();
        GameManager.Game.Hack.Browser.Omni.SetAddress(Address);
    }
}
