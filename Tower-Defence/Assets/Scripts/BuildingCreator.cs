using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    public GameObject[] buildingPrefab;
    public int numberOfBuildings;
    public float interval;
    public Vector2 firstBuildingPosition;

    // Start is called before the first frame update
    void Start()
    {
        //CreateBuildings();
    }

    [ContextMenu("Generate Buildings")]
    private void CreateBuildings()
    {
        for (int y = 0; y < numberOfBuildings; y++)
            for (int x = 0; x < numberOfBuildings; x++)
            {
                GameObject thisBuilding = Instantiate(buildingPrefab[(int)UnityEngine.Random.Range(0, 2)], new Vector3(firstBuildingPosition.x + x * interval, 0.5f, firstBuildingPosition.y + y * interval), Quaternion.identity);
                thisBuilding.transform.SetParent(transform);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
