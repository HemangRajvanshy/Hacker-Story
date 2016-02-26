using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public bool On { get; private set; }

    void Start()
    {
        On = true; //TODO: SAVE AND READ
    }
}
