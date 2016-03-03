using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class StoryManager : MonoBehaviour {

    public List<Story> Stories;

    public Canvas StoryCanvas;
    public Image StoryBackground;
    public Text Dialogue;
    public int LetterPerSec = 5;

    private Story CurrentStory;
    private int SceneNumber;
    private int DialogueNumber;
    private StoryScene CurrentScene;
    private bool Typing;


    public void Init(int StoryNumber) // Called by GameManager
    {
        StoryCanvas.enabled = true;
        CurrentStory = Stories[StoryNumber];
        SceneNumber = 0;
        DialogueNumber = 0;

        CurrentScene = CurrentStory.StoryScenes[SceneNumber];
        StoryBackground.sprite = CurrentScene.image;
        StartCoroutine(TypeText(CurrentScene.Dialogues[DialogueNumber]));
    }

    public void OnClick()
    {
        if (Typing)
        {
            Typing = false;
        }
        else
        {
            Next();
        }
    }

    private void Next() //Next Dialogue
    {
        if((CurrentScene.Dialogues.Count-1) > DialogueNumber) //Check if there are any more dialogues.
        {
            DialogueNumber++;
            NextDialogue(DialogueNumber);
        }
        else
        {
            if((CurrentStory.StoryScenes.Length-1) > SceneNumber) // Check if there are any more Story Scenes.
            {
                NextScene();
                if(CurrentStory.StoryScenes.Length-2 == SceneNumber)
                {
                    LastScene();
                }
            }
            else
            {
                Close();
            }
        }
    }

    IEnumerator TypeText(string text, float wait = 0f)
    {
        Dialogue.text = "";
        Typing = true;
        yield return new WaitForSeconds(wait);
        foreach (char letter in text)
        {
            if (Typing)
            {
                Dialogue.text += letter;
                if (Main.Instance.SfxMgr.TypingSfx)
                    Main.Instance.SfxMgr.Play(Main.Instance.SfxMgr.TypingSfx);
                yield return new WaitForSeconds(1 / LetterPerSec); 
            }
            else
            {
                Dialogue.text = text;
                break;
            }
        }
        Typing = false;
    }

    private void NextDialogue(int DialogueNmuber)
    {
        if (CurrentScene.SfxList[DialogueNumber] != null)
            Main.Instance.SfxMgr.Play(CurrentScene.SfxList[DialogueNumber]);
        StartCoroutine(TypeText(CurrentScene.Dialogues[DialogueNumber], CurrentScene.Delays[DialogueNumber]));
    }

    private void NextScene()
    {
        SceneNumber++;
        CurrentScene = CurrentStory.StoryScenes[SceneNumber];
        DialogueNumber = 0;
        NextDialogue(DialogueNumber);
        StoryBackground.sprite = CurrentScene.image;
    }

    private void LastScene()
    {
        Debug.Log("Last Scene, might as well start loading hack.");
    }

    private void Close()
    {
        StoryCanvas.enabled = false;
        GameManager.Game.StoryComplete();
        Debug.Log("Reached End of Story");
    }
}
