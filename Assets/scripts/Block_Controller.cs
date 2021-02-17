using UnityEngine;
using TMPro;

public class Block_Controller : MonoBehaviour
{
    public GameObject life;
    private int block_health = 1;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag != "NB")
        {
            GM.block_count++;
            switch (gameObject.tag)
            {
                case "B":
                    block_health = 1;
                    break;

                case "DB":
                    block_health = 2;
                    break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (gameObject.tag != "NB")
        {
            if (hit.gameObject.name == "Ball")
            {
                if (gameObject.tag == "DB")
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 0);
                block_health--;
            }
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {

        if (block_health <= 0)
        {
            GM.block_count--;
            Destroy(gameObject);

            switch (gameObject.tag)
            {
                case "B":
                    GM.score += 10;
                    GameObject.Find("Canvas").transform.Find("InGame_Score").GetComponent<TextMeshProUGUI>().SetText("Score: " + GM.score);
                    break;

                case "DB":
                    GM.score += 15;
                    GameObject.Find("Canvas").transform.Find("InGame_Score").GetComponent<TextMeshProUGUI>().SetText("Score: " + GM.score);
                    break;
            }
        }
    }
}
