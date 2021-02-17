using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    public static bool canMoveFreely = false;
    public static bool moveLeft = true;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    Vector2 speed;
    void Update()
    {
        if (isDead == true)
        {
            if (Input.touchCount > 0)
            {
                MovePaddle.launched_Ball = false;
                canMoveFreely = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (canMoveFreely)
        {
            rb.isKinematic = false;

            if (moveLeft)
            {
                speed.x = -5f;
                speed.y = 5f;
            }

            if (!moveLeft)
            {
                speed.x = 5f;
                speed.y = 5f;
            }

            rb.velocity = new Vector2(speed.x, speed.y);
        }

        canMoveFreely = false;

        if (MovePaddle.launched_Ball)
        {
            if (rb.velocity.x > 0f && rb.velocity.x != ballSpeed)
            {
                speed.x = ballSpeed;
                rb.velocity = new Vector2(speed.x, rb.velocity.y);
            }

            if (rb.velocity.x < 0f && rb.velocity.x != -ballSpeed)
            {
                speed.x = -ballSpeed;
                rb.velocity = new Vector2(speed.x, rb.velocity.y);
            }

            if (rb.velocity.y > 0f && rb.velocity.y != ballSpeed)
            {
                speed.y = ballSpeed;
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
            }

            if (rb.velocity.y < 0f && rb.velocity.y != -ballSpeed)
            {
                speed.y = -ballSpeed;
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "Bottom")
        {
            if (GM.block_count != 0)
            {
                GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("GameOver").GetComponent<TextMeshProUGUI>().SetText("Game Over. \n Tap to restart");
                isDead = true;
            }
            rb.isKinematic = true;
            rb.velocity = new Vector2(0f, 0f);
            transform.localPosition = new Vector3(-40f, 0f, 0f);
            canMoveFreely = false;
            MovePaddle.launched_Ball = false;
        }
    }
}
