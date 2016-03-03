using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public GameObject TutorialObj;
    public GameObject TextBubble1;
    public GameObject TextBubble2;

    public void StartTutorial()
    {
        TutorialObj.SetActive(true);
        Debug.Log("Tutorial Started!");
    }
}
