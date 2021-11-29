using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    float live = 2f;
    GameObject other;
    public WolfCreation script;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        other = GameObject.Find("gun");
        script = (WolfCreation)other.GetComponent(typeof(WolfCreation));
        live -= Time.deltaTime;
        if (live <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "PLAYER")
        {
            return;
        }
        else if (hitInfo.name == "Wolf(Clone)")
        {
            script.WolfHit();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
