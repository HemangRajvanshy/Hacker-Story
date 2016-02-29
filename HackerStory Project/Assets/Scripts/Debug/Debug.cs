using UnityEngine;
using System.IO;
using System.Collections;

namespace Debugging
{
    public class Debug : MonoBehaviour
    {
        public bool ClearSaveOnPlay;

        public bool DebugOn = false;

        void Awake()
        {
            if (ClearSaveOnPlay)
            {
                File.Delete(Application.persistentDataPath + "/info.dat");
            }
        }

    }
}