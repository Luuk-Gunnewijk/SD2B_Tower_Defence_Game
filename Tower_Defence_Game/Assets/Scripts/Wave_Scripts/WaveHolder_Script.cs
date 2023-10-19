using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveHolder_Script : MonoBehaviour
{
    public GameObject[] waves;

    [SerializeField] AudioClip victoryHorn;

    int currentWave;

    void Start()
    {
        GlobalData.waveIsDefeated = true;
        foreach (var wave in waves) 
        {
            wave.SetActive(false);
        }
        startWave();
    }

    void Update()
    {
        WaveIsDefeated();
        AllWavesAreDone();
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
        if (currentWave != waves.Length && GlobalData.waveIsDefeated)
        {
            waves[currentWave].SetActive(true);
            GlobalData.waveIsDefeated = false;
            currentWave++;
        } 
    }

    void AllWavesAreDone()
    {
        if (currentWave == waves.Length && GlobalData.waveIsDefeated) 
        {
            if (!SoundManager_Script.IsPlaying())
            {
                SoundManager_Script.PlayOneShot(victoryHorn);
                StartCoroutine(LoadNextSceneRoutine());
            }
        }
    }

    IEnumerator LoadNextSceneRoutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
