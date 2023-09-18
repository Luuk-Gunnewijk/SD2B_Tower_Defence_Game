using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower_01_Script : MonoBehaviour
{
    Transform enemy;
    public GameObject Arrow_01;

    [SerializeField] float distance;
    [SerializeField] float arrowSpeed;

    public float dirRot;

    bool canSpawnNextArrow = true;

    void Start()
    {
        enemy = GameObject.Find("Viking_01").transform;
    }

    void Update()
    {
        RayCast();
    }

    public void RayCast() 
    {
        Vector3 dir = enemy.position - transform.position;
        if (dir.magnitude > distance) { return; }
        if (Physics2D.Raycast(transform.position, dir, distance))
        {
            Debug.Log("Something hit");
            Debug.DrawRay(transform.position, dir, Color.red, 1);
            if(canSpawnNextArrow == true) 
            {
                var arrow = Instantiate(Arrow_01, transform.position, Quaternion.FromToRotation(Vector2.up, dir));
                StartCoroutine(SpawnNextArrow());
                arrow.GetComponent<Rigidbody2D>().velocity = dir * arrowSpeed;
                Destroy(arrow, 5f);
            }       
        }
        //(Physics2D.CircleCast(transform.position, 1, Vector2.one, distance))
    }

    IEnumerator SpawnNextArrow() 
    {
        canSpawnNextArrow = false;
        yield return new WaitForSeconds(1);
        canSpawnNextArrow = true;
    }
}
