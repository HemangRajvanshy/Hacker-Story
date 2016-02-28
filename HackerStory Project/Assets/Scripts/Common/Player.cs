using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public class Player : MonoBehaviour {

    public PlayerSave PlayerData { get; private set; }
    public bool PlayerDataExists { get { return PlayerDataExist(); } }

    void Awake()
    {
        Load();
    }

    void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");

        PlayerSave save = new PlayerSave();
        save = WriteSave();

        formatter.Serialize(file, save);
    }

    public void Load()
    {
        if(PlayerDataExist())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/info.dat", FileMode.Open);
            PlayerSave save = (PlayerSave)formatter.Deserialize(file);
            file.Close();

            InitializeFromSave(save);
        }
    }

    private bool PlayerDataExist()
    {
        return File.Exists(Application.persistentDataPath + "/info.dat");
    }

    private void InitializeFromSave(PlayerSave Save)
    {
        PlayerData = Save;
    }

    private PlayerSave WriteSave()
    {
        PlayerSave save = new PlayerSave();
        save.Music = Main.Instance.MusicMgr.On;
        save.Sfx = Main.Instance.SfxMgr.On;
        return save;
    }
}

[Serializable]
public class PlayerSave
{
    public bool Music;
    public bool Sfx;
}

