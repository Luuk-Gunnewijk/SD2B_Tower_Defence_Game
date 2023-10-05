using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grass_Tile_Script : MonoBehaviour
{
    Tower_Place_UI_Script myTower_Place_UI_Script;

    SpriteRenderer mySpriteRenderer;

    public GameObject tower_01_Prefab;
    public GameObject tower_02_Prefab;
    public GameObject tower_03_Prefab;

    Transform grassTile;

    private void Awake()
    {
        myTower_Place_UI_Script = FindAnyObjectByType<Tower_Place_UI_Script>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        grassTile = GetComponent<Transform>();
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        myTower_Place_UI_Script.OpenTowerUI(this);
    }

    void OnMouseOver()
    {
        mySpriteRenderer.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        mySpriteRenderer.color = Color.white;
    }

    public void PlaceTower_01() 
    {
        GameObject tower = Instantiate(tower_01_Prefab, grassTile);
        tower.transform.position = transform.position;

        myTower_Place_UI_Script.QuitButton();
    }

    public void PlaceTower_02()
    {
        GameObject tower = Instantiate(tower_02_Prefab, grassTile);
        tower.transform.position = transform.position;

        myTower_Place_UI_Script.QuitButton();
    }

    public void PlaceTower_03()
    {
        GameObject tower = Instantiate(tower_03_Prefab, grassTile);
        tower.transform.position = transform.position;

        myTower_Place_UI_Script.QuitButton();
    }
}
