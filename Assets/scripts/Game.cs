using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject brick;
    private int width = Screen.width / 42, height = Screen.height / 33;
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(false);

        for (int i = 0; i < height / 2; i += 2)
        {
            for (int j = 1; j < width; j += 2)
            {
                GameObject obj = Instantiate(brick);
                obj.transform.position += new Vector3((j - (width / 2)), i, 0);
                if (Random.Range(0, 3) == 0)
                {
                    obj.tag = "NB";
                    obj.GetComponent<SpriteRenderer>().color = Color.black;
                }
                else if (Random.Range(0, 3) == 1)
                {
                    obj.tag = "B";
                    obj.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    obj.tag = "DB";
                    obj.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }
}
