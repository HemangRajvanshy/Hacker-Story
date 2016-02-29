using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Story : MonoBehaviour
{
    public StoryScene[] StoryScenes;
}

[Serializable]
public struct StoryScene
{
    public List<String> Dialogues;
    public Sprite image;
}