using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public int speed = 15;
    public static bool launched_Ball = false;
    Vector3 mousePosition;
    Touch touch;
    private Vector2 direction;

    void Update()
    {
        if (launched_Ball)
        {

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary)
                {
                    if (touch.position.x < (Screen.width / 2) && transform.position.x > -8)
                    {
                        if (!BallLogic.canMoveFreely)
                            BallLogic.moveLeft = true;

                        gameObject.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
                    }
                    else if (touch.position.x > (Screen.width / 2) && transform.position.x < 8)
                    {
                        if (!BallLogic.canMoveFreely)
                            BallLogic.moveLeft = true;

                        gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                    }
                }
            }

#elif UNITY_EDITOR

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8)
            {
                if (!BallLogic.canMoveFreely)
                    BallLogic.moveLeft = true;

                gameObject.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8)
            {

                if (!BallLogic.canMoveFreely)
                    BallLogic.moveLeft = false;

                gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
#endif
        }
#if UNITY_ANDROID
        if (Input.touchCount > 0 && launched_Ball == false)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                BallLogic.canMoveFreely = true;
                launched_Ball = true;
            }
        }
#elif UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space) && launched_Ball == false)
        {
            BallLogic.canMoveFreely = true;
            launched_Ball = true;
        }
#endif
    }
}
