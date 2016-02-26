using UnityEngine;
using System.Collections;

public class PlayPanel : MonoBehaviour {

    public void Play()
    {
        Main.Instance.LoadGameScene();
    }
}
