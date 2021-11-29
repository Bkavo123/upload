using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalMove : MonoBehaviour
{
    int spd;
    float position;
    bool shot;

    void Start()
    {
        spd = -5;
    }

    void FixedUpdate()
    {
        Vector3 speed = new Vector3(spd * Time.deltaTime, 0, 0);

        transform.position += speed;

        if (transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Bullet(Clone)")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}