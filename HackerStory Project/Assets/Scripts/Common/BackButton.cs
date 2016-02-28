using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

    private Menu_UI menu;

    public void Back()
    {
        if(Application.loadedLevel == 0) // Menu Scene
        {
            if (!menu)
                menu = GameObject.Find("Canvas/BackgroundImage").GetComponent<Menu_UI>();
            menu.Back();
        }
    }
	
}
