using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Wave_Script : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] int SpawnNextEnemyTime;

    int currentEnemy = 0;
    bool canSpawnNextEnemy;

    private void Start()
    {
        canSpawnNextEnemy = true;

        foreach (var enemy in enemies) 
        { 
            enemy.SetActive(false);
            canSpawnNextEnemy = true;
        }
    }

    void Update()
    {
        if (canSpawnNextEnemy == true && currentEnemy !< enemies.Length) 
        {
            enemies[currentEnemy].SetActive(true);
            currentEnemy++;
            StartCoroutine(StartNextEnemyRoutine());
        }
        
        if (enemies.All(e => e == null) )
        {
            GlobalData.waveIsDefeated = true;
        }
    }

    IEnumerator StartNextEnemyRoutine()
    {
        canSpawnNextEnemy = false;
        yield return new WaitForSeconds(SpawnNextEnemyTime);
        canSpawnNextEnemy = true;
    }
}
