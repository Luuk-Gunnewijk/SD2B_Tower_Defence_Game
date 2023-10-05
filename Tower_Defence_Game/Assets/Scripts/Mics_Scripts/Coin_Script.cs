using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Coin_Script : MonoBehaviour
{

    void Update()
    {
        MoveCoinToTopRight();
        Destroy(gameObject, 5);
    }

    void MoveCoinToTopRight()
    {
        transform.position += new Vector3(4, 4.5f, 0) * Time.deltaTime;
    }
}
