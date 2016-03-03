using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Game;

    public TextType TextType;
    public StoryManager Story;
    public HackManager Hack;

    private int StoryIndex = 0;
    private int HackIndex = 0;


    #region UnityMethods
    void Awake()
    {
        if (!Game)
            Game = this;
    }

    void Start()
    {
        if (Main.Instance.PlayerData != null)
        {
            StoryIndex = Main.Instance.PlayerData.StoryIndex;
            HackIndex = Main.Instance.PlayerData.HackIndex;
        }
        if (StoryIndex == HackIndex)
            StartStory(StoryIndex);
        else
            StartHack(HackIndex);
        
    }

    #endregion

    #region PublicMethods
    public void StoryComplete()
    {
        StoryIndex++;
        Main.Instance.SavePlayerProgress(StoryIndex, HackIndex);
        StartHack(HackIndex);
    }
    public void HackComlete()
    {
        HackIndex++;
        Main.Instance.SavePlayerProgress(StoryIndex, HackIndex);
        StartStory(StoryIndex);
    }
    #endregion


    #region private Methods
    private void StartStory(int StoryIndx)
    {
        Story.Init(StoryIndex);
    }

    private void StartHack(int HackIndx)
    {
        Hack.Init(HackIndex);
    }
    #endregion

}
