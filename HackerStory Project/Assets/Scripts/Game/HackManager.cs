using UnityEngine;
using System.Collections;

public class HackManager : MonoBehaviour {

    public Canvas MonitorCanvas;

    public Tutorial Tutorial;
    public Desktop Desktop;

    public void Init(int HackNumber) // Called by GameManager
    {
        MonitorCanvas.enabled = true;
        if (HackNumber == 0)
            Tutorial.StartTutorial();
        Debug.Log("Start Hack Number: " + HackNumber);
    }
}
