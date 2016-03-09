using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TaskBar : MonoBehaviour {

    public GameObject ApplicationButton;
    public LayoutElement ButtonLayout;

    internal Dictionary<App, GameObject> OpenApps;

    protected virtual void Start()
    {
        ButtonLayout.preferredWidth = Screen.width / 5f;
        ApplicationButton.SetActive(false);
        OpenApps = new Dictionary<App, GameObject>();
    }

    public void OpenApplication(App app)
    {
        Debug.Log(OpenApps);
        if (!OpenApps.ContainsKey(app))
        {
            GameObject AppButton = Instantiate(ApplicationButton);
            AppButton.SetActive(true);
            AppButton.transform.SetParent(ApplicationButton.transform.parent);
            AppButton.transform.localScale = ApplicationButton.transform.localScale;
            AppButton.transform.position = ApplicationButton.transform.position;

            OpenApps.Add(app, AppButton);

            // Initialize the button
            TaskBarApp AppProp = AppButton.GetComponent<TaskBarApp>();
            AppProp.app = app;
            AppProp.Name.text = app.AppName;
            AppProp.Icon.sprite = app.Icon; 
        }
    }

    public void MinimizeApplication(App app)
    {
        TaskBarApp AppProp = OpenApps[app].GetComponent<TaskBarApp>();
    }

    public virtual void CloseApplication(App app)
    {
        Destroy(OpenApps[app]);
        OpenApps.Remove(app);
    }
}
