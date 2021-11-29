using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCreation : MonoBehaviour
{
    float randMin;
    float randMax;
    float randPos;
    float randSpawn;
    float spawnTime = 2;

    Vector3 startPos;

    bool test = true;

    public GameObject cowPrefab;
    Quaternion rotate = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        randMin = 2f;
        randMax = 3f;

        randSpawn = Random.Range(randMin, randMax);
    }

    void FixedUpdate()
    {
        startPos = new Vector3(9, randPos, -1);
        randPos = Random.Range(3.5f, -4.5f);

        CreatePrefab();
    }

    void CreatePrefab()
    {
        randSpawn -= Time.deltaTime;
        if (randSpawn <= 0)
        {
            randSpawn = Random.Range(randMin, randMax);
            Instantiate(cowPrefab, startPos, rotate);
        }
    }
}