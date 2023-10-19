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
    [SerializeField] int amountMoneyDrop;
    [SerializeField] int howLongForNextSound;
    bool HasDied = false;

    [Header("Enemy objects")]
    [SerializeField] Material WhiteMat;
    [SerializeField] Material defaultMat;
    [SerializeField] GameObject coins;
    [SerializeField] public AudioClip DiedSound;
    [SerializeField] public AudioClip HitSound;
    [SerializeField] public AudioClip enemyMainSound;

    GameObject coinPrefab;
    AudioSource audioSource;

    private void Awake()
    {
        myMain_Economy_Script = FindAnyObjectByType<Main_Economy_Script>(); 
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myLost_Script = FindAnyObjectByType<Lost_Script>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundRoutine());
    }

    void Update()
    {
        EnemyHasDied();
    }

    void EnemyHasDied() 
    {
        if (Health <= 0 && !HasDied) 
        {
            audioSource.PlayOneShot(DiedSound, 1.0f);
            myMain_Economy_Script.GainXAmountOfMoney(amountMoneyDrop);
            coinPrefab = Instantiate(coins, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, DiedSound.length);
            HasDied = true;
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
            audioSource.PlayOneShot(HitSound, 1.0f);
            Health -= other.gameObject.GetComponent<Projectile_Script>().towerScript.projecttileDamage;
            //Health--;
            StartCoroutine(DamageSpriteRoutine());
        }
    }

    IEnumerator DamageSpriteRoutine()
    {
        mySpriteRenderer.material = WhiteMat;
        yield return new WaitForSeconds(.1f);
        mySpriteRenderer.material = defaultMat;
    }

    IEnumerator PlaySoundRoutine()
    {
        yield return new WaitForSeconds(enemyMainSound.length + howLongForNextSound + Random.Range(5, 20));
        if (!SoundManager_Script.IsPlaying())
        {
            SoundManager_Script.PlayOneShot(enemyMainSound);
        }
        StartCoroutine(PlaySoundRoutine());
    }
}
