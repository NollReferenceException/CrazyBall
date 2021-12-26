using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    public GameObject[] ArrayToRestart;
    
    public void Restart()
    {
        for (int i = 0; i < ArrayToRestart.Length; i++)
        {
            ArrayToRestart[i].GetComponent<IRestartable>().RestartThisObject();
        }
    }
}
