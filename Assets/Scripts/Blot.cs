using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blot : MonoBehaviour
{

    private Interface inter;
    public float floatHeight = 50;     // Desired floating height.
    public float liftForce = 20;       // Force to apply when lifting the rigidbody.
    public float damping = 10;         // Force reduction proportional to speed (reduces bouncing).
    public bool isStopMove;

    private void Start()
    {
        inter = GameObject.Find("Interface").GetComponent<Interface>();


    }

    public void isWin()
    {
        inter.SwipeAmount++;
        inter.AddToSwipe();
        if (inter.SwipeAmount % 5 == 0)
        {
            inter.SpawnCang();
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            transform.position = new Vector2(Random.Range(-1f, 1f), YPosSetter());
            isWin();

        }

    }

    public void Update()
    {
        if (isStopMove != true)
        {

            transform.Translate(Vector3.down * Time.deltaTime * ToiletPaperSpawner.paperSpeed);

        }
    }

    private float YPosSetter()
    {

        return Random.Range(20f, ToiletPaperSpawner.HeightSpawn);
    }
}
