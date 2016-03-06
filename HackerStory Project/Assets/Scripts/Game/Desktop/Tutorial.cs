using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public GameObject TutorialObj;
    public GameObject TextBubble1;
    public Text Text1;
    public GameObject TextBubble2;
    public Text Text2;
    public List<string> Messages;
    public List<int> BubbleNum;

    private int currentMessage = 0;

    public void StartTutorial()
    {
        TutorialObj.SetActive(true);
        OnClick();
        Debug.Log("Tutorial Started!");
    }

    public void OnClick()
    {
        if (Messages.Count>currentMessage)
        {
            Deactivate();
            switch (BubbleNum[currentMessage])
            {
                case 1:
                    TextBubble1.SetActive(true);
                    StartCoroutine(GameManager.Game.TextType.TypeText(Text1, Messages[currentMessage]));
                    break;
                case 2:
                    TextBubble2.SetActive(true);
                    StartCoroutine(GameManager.Game.TextType.TypeText(Text2, Messages[currentMessage]));
                    break;
            }
            currentMessage++; 
        }
        else
        {
            Deactivate();
            GameManager.Game.Hack.TutorialComplete();
        }
    }


    private void Deactivate()
    {
        TextBubble1.SetActive(false);
        TextBubble2.SetActive(false);
    }
}
