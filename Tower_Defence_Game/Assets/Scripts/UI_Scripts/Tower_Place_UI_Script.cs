using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower_Place_UI_Script : MonoBehaviour
{
    Grass_Tile_Script currentClickedGrassTileScript;

    public Canvas myCanvas;
    public Button my_Place_Tower_01_Button;

    bool towerUIIsOpen = false;

    void Awake()
    {
    }

    private void Start()
    {
        myCanvas.enabled = false;
    }

    void Update()
    {
                    
    }
    public void OpenTowerUI(Grass_Tile_Script grass_Tile_Script) 
    {
        currentClickedGrassTileScript = grass_Tile_Script;
        myCanvas.enabled = true;
        towerUIIsOpen = true;
    }

    public void Pressed_Tower_01_Button() 
    {
        if (towerUIIsOpen == true)
        {
            currentClickedGrassTileScript.PlaceTower_01();
        }
    }

    public void QuitButton() 
    {
        myCanvas.enabled = false;
    }
}
