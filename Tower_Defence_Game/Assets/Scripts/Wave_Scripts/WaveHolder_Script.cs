using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHolder_Script : MonoBehaviour
{
    public GameObject[] waves;

    int currentWave;

    void Start()
    {
        foreach (var wave in waves) 
        {
            wave.SetActive(false);
        }
        startWave();
    }

    void Update()
    {
        WaveIsDefeated();
    }

    void WaveIsDefeated()
    {
        if (GlobalData.waveIsDefeated == true) 
        {
            //Debug.Log("Next Wave");
            startWave();
        }
    }

    void startWave()
    {
        if (currentWave !< waves.Length)
        {
            waves[currentWave].SetActive(true);
            currentWave++;
            GlobalData.waveIsDefeated = false;
        }
            
    }
}
