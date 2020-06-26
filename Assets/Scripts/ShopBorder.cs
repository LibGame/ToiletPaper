using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBorder : MonoBehaviour
{
    private Rigidbody2D ShopLineRB;

    void Start()
    {
        ShopLineRB = GameObject.Find("ShopLine").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            ShopLineRB.constraints = RigidbodyConstraints2D.FreezePositionX;
            ShopLine._isLeft = false;

        }
        if (collision.gameObject.tag == "Left")
        {
            ShopLineRB.constraints = RigidbodyConstraints2D.FreezePositionX;
            ShopLine._isRight = false;


        }
    }



}
