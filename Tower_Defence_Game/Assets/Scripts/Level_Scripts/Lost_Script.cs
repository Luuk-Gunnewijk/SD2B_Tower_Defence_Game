using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost_Script : MonoBehaviour
{
    public float mainHealth;

    private void Update()
    {
        YouLost();
    }

    void YouLost()
    {
        if (mainHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
