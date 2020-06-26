using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public GameObject lineGO;
    private TrailRenderer trail;
    public static bool isRight;
    private Vector3 offset;
    private Camera cameras;
    public BoxCollider2D colider;
    public static bool isCanMove = true;


    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        cameras = Camera.main;

    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    colider.enabled = true;
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
                    transform.position = cameras.ScreenToWorldPoint(newPosition);
                    if (touch.position.x > startPos.x)
                    {
                        isRight = true;
                    }
                    else
                    {
                        isRight = false;

                    }
                    break;

                case TouchPhase.Ended:

                    break;
            }
        }

    }
}
