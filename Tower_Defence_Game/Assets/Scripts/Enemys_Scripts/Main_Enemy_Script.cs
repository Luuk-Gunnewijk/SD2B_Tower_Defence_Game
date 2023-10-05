using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Main_Enemy_Script : MonoBehaviour
{
    Lost_Script myLost_Script;
    Main_Economy_Script myMain_Economy_Script;
    SpriteRenderer mySpriteRenderer;

    //[Tooltip("This is the status from the enemies")]
    [Header("Enemey status")]
    [SerializeField] int Health;
    [SerializeField] int damage;
    [SerializeField] float moveSpeed;
    [SerializeField] int amountMoneyDrop;

    [Header("Enemy objects")]
    [SerializeField] Material WhiteMat;
    [SerializeField] Material defaultMat;
    [SerializeField] GameObject coins;

    GameObject coinPrefab;

    private void Awake()
    {
        myMain_Economy_Script = FindAnyObjectByType<Main_Economy_Script>(); 
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myLost_Script = FindAnyObjectByType<Lost_Script>();   
    }

    void Update()
    {
        EnemyHasDied();;
    }

    void EnemyHasDied() 
    {
        if (Health <= 0) 
        {
            myMain_Economy_Script.GainXAmountOfMoney(amountMoneyDrop);
            coinPrefab = Instantiate(coins, gameObject.transform.position, Quaternion.identity);
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
            StartCoroutine(DamageSpriteRoutine());
        }
    }

    IEnumerator DamageSpriteRoutine()
    {
        mySpriteRenderer.material = WhiteMat;
        yield return new WaitForSeconds(.1f);
        mySpriteRenderer.material = defaultMat;
    }
}
