using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public int spd = 3;
    int dirX;
    int dirY;
    public float dir = 3;

    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        float moving = Mathf.Abs(dirX) + Mathf.Abs(dirY);

        animator.SetFloat("SpeedX", dirX);
        animator.SetFloat("SpeedY", dirY);
        animator.SetFloat("Speed", moving);

        if (dirX == 1)
        {
            dir = 1;
        }
        else if (dirX == -1)
        {
            dir = 2;
        }
        else if (dirY == 1)
        {
            dir = 3;
        }
        else if (dirY == -1)
        {
            dir = 4;
        }

        animator.SetFloat("Direction", dir);

        Vector3 move = new Vector3(spd * dirX * Time.deltaTime, spd * dirY * Time.deltaTime, 0);

        transform.position += move;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "animal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
