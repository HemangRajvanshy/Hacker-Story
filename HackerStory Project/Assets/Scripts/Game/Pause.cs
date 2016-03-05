using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    public Canvas PauseCanvas;

    private bool Paused;

    void Start()
    {
        Paused = false;
        PauseCanvas.enabled = false;
    }

    public void Pause_Resume()
    {
        if(Paused)
        {
            Paused = false;
            PauseCanvas.enabled = false;
        }
        else
        {
            Paused = true;
            PauseCanvas.enabled = true;
        }
    }

    public void Menu()
    {
        Main.Instance.LoadMenuScene();
    }
}
