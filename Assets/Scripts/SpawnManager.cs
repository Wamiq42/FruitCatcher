using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float rangeX = 16;
    private int indexNumber;
    private float startTime = 1;
    private float intervalTime = 2.5f;
    private Vector3 randomPosition;
    private GameObject tempGameObject;

    public GameObject[] fruitsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFruits", startTime, intervalTime);
    }

    void SpawnFruits()
    {
        randomPosition = new Vector3(RandomPosition(), 0.8f, RandomPosition());
        indexNumber = RandomIndex();
        tempGameObject = Instantiate(fruitsPrefab[indexNumber], randomPosition, fruitsPrefab[indexNumber].transform.rotation);
        Destroy(tempGameObject, 10.0f);
    }

    int RandomIndex()
    {
        return Random.Range(0, fruitsPrefab.Length);
    }

    float RandomPosition()
    {
        return Random.Range(-rangeX, rangeX);
    }
}
