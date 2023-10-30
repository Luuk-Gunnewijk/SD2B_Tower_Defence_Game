using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Towers_Script : MonoBehaviour
{
    Transform enemy;
    public GameObject ProjectTile;

    [SerializeField] float distance;
    [SerializeField] float arrowSpeed;
    [SerializeField] public int projecttileDamage;
    [SerializeField] float spawnNextProjectTile;

    float dirRot;

    bool canSpawnNextArrow = true;

    void Update()
    {
        FindCorrectEnemy();
        ShootProjectTiles();
    }

    public void ShootProjectTiles() 
    {
        if (!enemy)
        {
            return;
        }
        Vector3 dir = enemy.position - transform.position;
        if (Physics2D.Raycast(transform.position, dir, distance))
        {
            //Debug.Log("Something hit");
            Debug.DrawRay(transform.position, dir, Color.red, 1);
            if(canSpawnNextArrow == true) 
            {
                var arrow = Instantiate(ProjectTile, transform.position, Quaternion.FromToRotation(Vector2.up, dir));
                StartCoroutine(SpawnNextProjectTile());
                arrow.GetComponent<Projectile_Script>().towerScript = this;
                arrow.GetComponent<Rigidbody2D>().velocity = dir.normalized * arrowSpeed;
                if (dir == null) { Destroy(arrow, 1f); }
                Destroy(arrow, 5f);
            }
        }
        //(Physics2D.CircleCast(transform.position, 1, Vector2.one, distance))
    }

    IEnumerator SpawnNextProjectTile() 
    {
        canSpawnNextArrow = false;
        yield return new WaitForSeconds(spawnNextProjectTile);
        canSpawnNextArrow = true;
    }

    bool IsEnemyInRange(Transform enemyTransform)
    {
        Vector3 dir = enemyTransform.position - transform.position;
        return dir.magnitude < distance;
    }

    void FindCorrectEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int closestPathFindingIndex = -1;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!IsEnemyInRange(enemies[i].transform))
            {
                continue;
            }
            int index = enemies[i].GetComponent<PathFinding_Script>().GetCurrentNodeIndex();
            if (index > closestPathFindingIndex)
            {
                enemy = enemies[i].transform;
                closestPathFindingIndex = index;
            }
        }
    }
}
