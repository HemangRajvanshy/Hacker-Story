using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public static Main Instance;


    #region UnityMethods
    void Awake()
    {
        Instance = this;
    }
    #endregion

    #region publicMethods
    public void LoadGameScene()
    {
        Debug.Log("TODO Load Game Scene");
    }

    public void LoadMenuScene()
    {
        Debug.Log("TODO: Load Menu Scene");
    }

    #endregion

    #region privateMethods
    private void ShowLoadingScreen()
    {
        Debug.Log("TODO: Show LoadingScreen");
    }
    #endregion
}
