using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Game;

    public TextType TextType;
    public StoryManager Story;
    public HackManager Hack;
    public Pause Pause;
//RemoveIfNotNeeded:   public Camera MainCamera;

    private int StoryIndex = 0;
    private int HackIndex = 0;
    private GameState state;

    private enum GameState
    {
        Story,
        Hack
    };

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

    public void OnClick(UnityEngine.EventSystems.RaycastResult ray)
    {
        if (ray.module.name == "PauseCanvas")
            return;
        switch (state)
        {
            case GameState.Hack:
                Hack.OnClick();
                break;
            case GameState.Story:
                Story.OnClick();
                break;
        }
    }

    public void OnBack()
    {
        Pause.Pause_Resume();
    }
    #endregion


    #region private Methods
    private void StartStory(int StoryIndx)
    {
        state = GameState.Story;
        Story.Init(StoryIndex);
    }

    private void StartHack(int HackIndx)
    {
        state = GameState.Hack;
        Hack.Init(HackIndex);
    }
    #endregion

}
