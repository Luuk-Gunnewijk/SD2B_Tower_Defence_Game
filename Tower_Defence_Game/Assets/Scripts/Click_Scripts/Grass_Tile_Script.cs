using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_Tile_Script : MonoBehaviour
{
    Tower_Place_UI_Script myTower_Place_UI_Script;

    public GameObject tower_01_Prefab;

    Transform grassTile;

    private void Awake()
    {
        myTower_Place_UI_Script = FindAnyObjectByType<Tower_Place_UI_Script>();
    }

    void Start()
    {
        grassTile = GetComponent<Transform>();
    }

    void OnMouseDown()
    {
        myTower_Place_UI_Script.OpenTowerUI(this);
    }

    public void PlaceTower_01() 
    {
        GameObject tower = Instantiate(tower_01_Prefab, grassTile);
        tower.transform.position = transform.position;

        myTower_Place_UI_Script.QuitButton();
    }
}
