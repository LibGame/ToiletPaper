using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoublePapaer : MonoBehaviour
{
    private Blot blot;
    private Interface inter;


    void Start()
    {
        blot = FindObjectOfType<Blot>();
        inter = FindObjectOfType<Interface>();
    }


    public void ChangePosition()
    {

        while (true)
        {
            Vector2 position = new Vector2(Random.Range(-1f, 1f), Random.Range(20f, YPosSetter()));

            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f, 1);

            if (colliders.Length == 0)
            {
                transform.position = position;
                colliders = null;

                break;
            }


        }

    }

    public void Update()
    {
        if (blot.isStopMove != true)
        {

            transform.Translate(Vector3.down * Time.deltaTime * ToiletPaperSpawner.paperSpeed);

        }
    }

    private float YPosSetter()
    {
        return Random.Range(20f, ToiletPaperSpawner.HeightSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            ChangePosition();
            inter.HelthMinus(true);
        }

    }
}
