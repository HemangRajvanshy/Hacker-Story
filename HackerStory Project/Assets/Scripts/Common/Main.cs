using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public static Main Instance;

    public MusicManager MusicMgr;
    public SfxManager SfxMgr;
    public GameObject LoadScreen;
    public Player player;

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
        ShowLoadingScreen("Menu");
        Application.LoadLevel("Menu");
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
