using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding_Script : MonoBehaviour
{
    [SerializeField] GameObject[] pathObjects;

    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem dustParticle;

    private int currentNodeIndex = 0;
    bool canSpawnParticle = true;
    int spawnNextParticleTime = 1;

    void Update()
    {
        FollowPath();
        CheckNodeReached();

        //SpawnParticle();
    }

    void FollowPath()
    {
        transform.position = Vector2.MoveTowards(transform.position, pathObjects[currentNodeIndex].transform.position, moveSpeed * Time.deltaTime);    
    }

    void CheckNodeReached() 
    {
        if (transform.position == pathObjects[currentNodeIndex].transform.position)
        {
            if (currentNodeIndex < pathObjects.Length - 1)
            {
                currentNodeIndex++;
            }
        }
    }

    void SpawnParticle()
    {
        if (canSpawnParticle == true) 
        {
            Instantiate(dustParticle, transform.position, Quaternion.identity);
            StartCoroutine(SpawnNextParticleRoutine());
            Destroy(dustParticle, 1f);
        }
    }

    IEnumerator SpawnNextParticleRoutine()
    {
        canSpawnParticle = false;
        yield return new WaitForSeconds(spawnNextParticleTime);
        canSpawnParticle = true;
    }
}
