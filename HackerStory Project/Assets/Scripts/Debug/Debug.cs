using UnityEngine;
using System.IO;
using System.Collections;

public class Debug : MonoBehaviour {

    public bool ClearSaveOnPlay;

    void Awake()
    {
        if(ClearSaveOnPlay)
        {
            File.Delete(Application.persistentDataPath + "/info.dat");
        }
    }
}
