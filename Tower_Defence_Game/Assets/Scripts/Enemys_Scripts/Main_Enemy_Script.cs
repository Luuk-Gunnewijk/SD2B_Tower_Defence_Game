using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Main_Enemy_Script : MonoBehaviour
{
    Lost_Script myLost_Script;

    //[Tooltip("This is the status from the enemies")]
    [Header("Enemey status")]
    [SerializeField] int Health;
    [SerializeField] int damage;
    [SerializeField] float moveSpeed;

    private void Awake()
    {
        myLost_Script = FindAnyObjectByType<Lost_Script>();   
    }

    void Update()
    {
        MoveToTheRightTest();

        EnemyHasDied();
    }

    void MoveToTheRightTest()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }

    void EnemyHasDied() 
    {
        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EndPoint")
        {
            myLost_Script.mainHealth -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Projecttiles")
        {
            Health--;
        }
    }
}
