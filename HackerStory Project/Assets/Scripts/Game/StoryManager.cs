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
        Dialogue.text = CurrentScene.Dialogues[DialogueNumber];
    }

    public void Next() //Next Dialogue
    {
        if((CurrentScene.Dialogues.Count-1) > DialogueNumber) //Check if there are any more dialogues.
        {
            DialogueNumber++;
            Dialogue.text = CurrentScene.Dialogues[DialogueNumber];
        }
        else
        {
            if((CurrentStory.StoryScenes.Length-1) > SceneNumber) // Check if there are any more Story Scenes.
            {
                SceneNumber++;
                CurrentScene = CurrentStory.StoryScenes[SceneNumber];
                DialogueNumber = 0;
                Dialogue.text = CurrentScene.Dialogues[DialogueNumber];
                StoryBackground.sprite = CurrentScene.image;
            }
            else
            {
                Close();
            }
        }
    }

    private void Close()
    {
        StoryCanvas.enabled = false;
        Debug.Log("Reached End of Story");
    }
}
