using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{
    public static int score;
    public static int block_count = 0;

    void Update()
    {
        float t = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
        Camera.main.backgroundColor = Color.Lerp(new Color(0.6f, 0.2f, 0.6f), new Color(0.8f, 0.8f, 0.3f), t);
        if (block_count == 0)
        {
            GameObject score = GameObject.Find("Canvas").transform.Find("Score").gameObject;
            score.SetActive(true);
            MovePaddle.launched_Ball = false;
            BallLogic.canMoveFreely = false;
            score.GetComponent<TextMeshProUGUI>().SetText("You Win \n Score is: " + GM.score.ToString());
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
