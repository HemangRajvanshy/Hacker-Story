using UnityEngine;
using System.Collections;

public class HackManager : MonoBehaviour {

    public void Init(int HackNumber) // Called by GameManager
    {
        Debug.Log("Start Hack Number: " + HackNumber);
    }
}
