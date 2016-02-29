using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Game;

    public StoryManager Story;

    private int StoryIndex;
    private int HackIndex;

    void Awake()
    {
        if (!Game)
            Game = this;
    }


}
