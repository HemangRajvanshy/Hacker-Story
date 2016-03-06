using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TaskBar : MonoBehaviour {

    public GameObject ApplicationButton;
    public LayoutElement ButtonLayout;

    private Dictionary<GameObject, App> OpenApps;

    void Start()
    {
        ButtonLayout.preferredWidth = Screen.width / 5f;
    }

    public void OpenApplication()
    {

    }
}
