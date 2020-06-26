using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLine : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    private Rigidbody2D rb;
    public static bool _isRight = true;
    public static bool _isLeft = true;
    private bool _isWasRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    private  void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    rb.constraints = RigidbodyConstraints2D.None;

                    direction = touch.position - startPos;
                    if (touch.position.x > startPos.x && _isRight)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * 15f);
                        _isWasRight = true;
                        _isLeft = true;
                    }
                    if(touch.position.x < startPos.x && _isLeft)
                    {
                        transform.Translate(Vector3.left* Time.deltaTime * 15f);
                        _isWasRight = false;
                        _isRight = true;
                    }
                    break;

                case TouchPhase.Ended:

                    if (_isWasRight)
                    {
                        rb.AddForce(-Vector2.left * 0.5f, ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb.AddForce(Vector2.left * 0.5f, ForceMode2D.Impulse);

                    }
                    break;
            }
        }
    }
}
