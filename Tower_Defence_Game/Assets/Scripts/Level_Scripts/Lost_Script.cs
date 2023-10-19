using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lost_Script : MonoBehaviour
{
    public TextMeshProUGUI heartsText;
    public float mainHealth;

    private void Update()
    {
        YouLost();
        heartsText.text = mainHealth.ToString();
    }

    void YouLost()
    {
        if (mainHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
