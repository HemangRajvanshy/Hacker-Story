using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskBarApp : MonoBehaviour {

    public Image Icon;
    public Text Name;
    public App app;

    public void OnClick()
    {
        if (app.open && app.transform.GetSiblingIndex() == (app.transform.parent.childCount-1))
            app.Minimize();
        else
            app.Open();
    }
}
