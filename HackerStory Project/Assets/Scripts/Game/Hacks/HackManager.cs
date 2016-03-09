using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HackManager : MonoBehaviour {

    public Canvas MonitorCanvas;

    public List<GameObject> Hacks;
    public Tutorial Tutorial;
    public Desktop Desktop;

    [HideInInspector]
    public Hack CurrentHack;

    private bool InTutorial = false;

    public void Init(int HackNumber) // Called by GameManager
    {
        MonitorCanvas.enabled = true;
        if (HackNumber == 0)
        {
            InTutorial = true;
            Tutorial.StartTutorial();
        }
        CurrentHack = Hacks[HackNumber].GetComponent<Hack>();
        Instantiate(Hacks[HackNumber]);
        Debug.Log("Started Hack Number: " + HackNumber);
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
