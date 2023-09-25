using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauze_Menu_Script : MonoBehaviour
{
    public Canvas myPauzeCanvas;

    void Start()
    {
        myPauzeCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            myPauzeCanvas.enabled = !myPauzeCanvas.enabled;
        }
        
    }

    public void ResumeGame()
    {
        myPauzeCanvas.enabled = false;
    }
}
