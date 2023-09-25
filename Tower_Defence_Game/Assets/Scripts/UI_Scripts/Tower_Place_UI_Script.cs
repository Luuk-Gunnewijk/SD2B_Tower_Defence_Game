using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Tower_Place_UI_Script : MonoBehaviour
{
    Main_Economy_Script myMain_Economy_Script;
    Grass_Tile_Script currentClickedGrassTileScript;

    public Canvas myCanvas;
    public TextMeshProUGUI myNotEnoughMoneyText;
    //public Button my_Place_Tower_01_Button;

    bool towerUIIsOpen = false;

    int popUpSec = 1;

    int costOfTower_01 = 50;
    int costOfTower_02 = 50;
    int costOfTower_03 = 100;

    void Awake()
    {
        myMain_Economy_Script = FindAnyObjectByType<Main_Economy_Script>();

        myNotEnoughMoneyText.enabled = false;
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
            if (costOfTower_01 <= myMain_Economy_Script.money)
            {
                currentClickedGrassTileScript.PlaceTower_01();
                myMain_Economy_Script.money -= costOfTower_01;
            }
            else
            {
                StartCoroutine(PopUpTextRoutine());
            }
            
        }
    }

    public void Pressed_Tower_02_Button()
    {
        if (towerUIIsOpen == true)
        {
            if (costOfTower_02 <= myMain_Economy_Script.money)
            {
                currentClickedGrassTileScript.PlaceTower_02();
                myMain_Economy_Script.money -= costOfTower_02;
            }
            else
            {
                StartCoroutine(PopUpTextRoutine());
            }

        }
    }

    public void Pressed_Tower_03_Button()
    {
        if (towerUIIsOpen == true)
        {
            if (costOfTower_02 <= myMain_Economy_Script.money)
            {
                currentClickedGrassTileScript.PlaceTower_03();
                myMain_Economy_Script.money -= costOfTower_03;
            }
            else
            {
                StartCoroutine(PopUpTextRoutine());
            }

        }
    }

    public void QuitButton() 
    {
        myCanvas.enabled = false;
    }

    IEnumerator PopUpTextRoutine()
    {
        myNotEnoughMoneyText.enabled = true;
        yield return new WaitForSeconds(popUpSec);
        myNotEnoughMoneyText.enabled = false;

    }
}
