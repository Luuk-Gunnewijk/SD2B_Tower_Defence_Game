using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests_Click : MonoBehaviour
{

    [SerializeField] string name;

    private void OnMouseDown()
    {
        Debug.Log(name);
    }
}
