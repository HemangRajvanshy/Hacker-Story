using UnityEngine;
using System.Collections;

public class HackManager : MonoBehaviour {

    public Canvas MonitorCanvas;

    public Tutorial Tutorial;
    public Desktop Desktop;

    private bool InTutorial = false;

    public void Init(int HackNumber) // Called by GameManager
    {
        MonitorCanvas.enabled = true;
        if (HackNumber == 0)
        {
            InTutorial = true;
            Tutorial.StartTutorial();
        }
        Debug.Log("Start Hack Number: " + HackNumber);
    }

    public void OnClick()
    {
        if (InTutorial)
            Tutorial.OnClick();
    }

    public void TutorialComplete()
    {
        InTutorial = false;
        Debug.Log("Tutorial Complete!");
    }
}
