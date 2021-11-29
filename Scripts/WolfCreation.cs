using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfCreation : MonoBehaviour
{
    public float randMin;
    public float randMax;
    float minmin = .01f;
    float minsub = .0003f;
    float randPos;
    float randSpawn;
    float spawnTime = 2;
    int score;
    int prevscore;

    Vector3 startPos;

    bool test = true;

    public GameObject wolfPrefab;
    public Text scoreText;
    Quaternion rotate = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        randMin = 1.5f;
        randMax = 2.5f;

        randSpawn = Random.Range(randMin, randMax);
        SetScoreText();
    }

    void FixedUpdate()
    {
        startPos = new Vector3(9, randPos, -1);
        randPos = Random.Range(3.5f, -4.5f);

        CreatePrefab();
        if (randMin <= 0)
        {
            randMin = .7f;
            randMax = .9f;
            minmin = 0;
        }
    }

    void CreatePrefab()
    {
        randSpawn -= Time.deltaTime;
        if (randSpawn <= 0)
        {
            randSpawn = Random.Range(randMin, randMax);
            Instantiate(wolfPrefab, startPos, rotate);
        }
    }

    public void WolfHit()
    {
        score += 1; 
        randMin -= minmin;
        randMax -= minmin;
        minmin -= minsub;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }
}