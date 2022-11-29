using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tile1, tile2;
    [SerializeField] private GameObject startTile;

    private float index = 0;

    private void Start()
    {
        GameObject startPlane1 = Instantiate(startTile, transform);
        startPlane1.transform.position = new Vector3(7, 0, 0);
        GameObject startPlane2 = Instantiate(startTile, transform);
        startPlane2.transform.position = new Vector3(-1, 0, 0);
        GameObject startPlane3 = Instantiate(startTile, transform);
        startPlane3.transform.position = new Vector3(-9, 0, 0);
        GameObject startPlane4 = Instantiate(startTile, transform);
        startPlane4.transform.position = new Vector3(-17, 0, 0);
        GameObject startPlane5 = Instantiate(startTile, transform);
        startPlane5.transform.position = new Vector3(-25, 0, 0);

    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);
        if(transform.position.x >= index)
        {
            int randomInt1 = Random.Range(0, 2);
            if(randomInt1 == 1)
            {
                GameObject tempTile1 = Instantiate(tile1, transform);
                tempTile1.transform.position = new Vector3(-16, 0, 0);
            }
            else if( randomInt1 == 0)
            {
                GameObject tempTile1 = Instantiate(tile2, transform);
                tempTile1.transform.position = new Vector3(-16, 0, 0);
            }

            int randomInt2 = Random.Range(0, 2);

            if (randomInt2 == 1)
            {
                GameObject tempTile2 = Instantiate(tile1, transform);
                tempTile2.transform.position = new Vector3(-25, 0, 0);
            }
            else if (randomInt2 == 0)
            {
                GameObject tempTile2 = Instantiate(tile2, transform);
                tempTile2.transform.position = new Vector3(-24, 0, 0);
            }

            index = index + 15.95f;
        }
    }
}
