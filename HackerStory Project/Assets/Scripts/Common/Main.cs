using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    //https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/persistence-data-saving-loading 30mins
    //http://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
    public static Main Instance;

    public MusicManager MusicMgr;
    public SfxManager SfxMgr;

    public GameObject LoadScreen;

    #region UnityMethods
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    #endregion

    #region publicMethods
    public void LoadGameScene()
    {
        ShowLoadingScreen("Game");
        Application.LoadLevel("Game");
    }

    public void LoadMenuScene()
    {
        Debug.Log("TODO: Load Menu Scene");
    }

    #endregion

    #region privateMethods

    #region Loading
    private AsyncOperation async;

    private void ShowLoadingScreen(string Level)
    {
        LoadScreen.SetActive(true);
        StartCoroutine(WaitToLoad(Level));
    }

    IEnumerator WaitToLoad(string Level)
    {
        async = Application.LoadLevelAsync(Level);
        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        LoadScreen.SetActive(false);
    }
    #endregion
    
    #endregion
}
