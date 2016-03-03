using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class StoryManager : MonoBehaviour {

    public List<Story> Stories;

    public Canvas StoryCanvas;
    public Image StoryBackground;
    public Text Dialogue;

    private Story CurrentStory;
    private int SceneNumber;
    private int DialogueNumber;
    private StoryScene CurrentScene;

    public void Init(int StoryNumber) // Called by GameManager
    {
        StoryCanvas.enabled = true;
        CurrentStory = Stories[StoryNumber];
        SceneNumber = 0;
        DialogueNumber = 0;

        CurrentScene = CurrentStory.StoryScenes[SceneNumber];
        StoryBackground.sprite = CurrentScene.image;
        NextDialogue(DialogueNumber);
    }

    public void OnClick()
    {
        if (GameManager.Game.TextType.Typing)
        {
            GameManager.Game.TextType.StopTyping();
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

    
    private void NextDialogue(int DialogueNmuber)
    {
        if (CurrentScene.SfxList[DialogueNumber] != null)
            Main.Instance.SfxMgr.Play(CurrentScene.SfxList[DialogueNumber]);
        StartCoroutine(GameManager.Game.TextType.TypeText(Dialogue, CurrentScene.Dialogues[DialogueNumber], CurrentScene.Delays[DialogueNumber]));
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
