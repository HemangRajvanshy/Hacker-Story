using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Game;

    public StoryManager Story;

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
        {
            Story.Init(StoryIndex);
        }
    }

    #endregion

    #region PublicMethods
    public void StoryComplete()
    {
        StoryIndex++;
        Main.Instance.SavePlayerProgress(StoryIndex, HackIndex);
    }
    public void HackComlete()
    {
        HackIndex++;
        Main.Instance.SavePlayerProgress(StoryIndex, HackIndex);
    }
    #endregion

}
