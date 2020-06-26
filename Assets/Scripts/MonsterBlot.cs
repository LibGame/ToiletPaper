using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBlot : MonoBehaviour
{

    private int _helth = 5;
    public SpriteRenderer spRender;
    public Sprite[] sprite;
    private Vector2 _startSize;
    private Blot blot;
    void Start()
    {
        spRender.sprite = sprite[Random.Range(0,sprite.Length)];
        blot = GameObject.FindObjectOfType<Blot>();
        _startSize = transform.localScale;
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
                transform.localScale = _startSize;

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

    private void HelthMinus()
    {
        _helth--;
        transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
        if(_helth <= 0)
        {
            ChangePosition();
            transform.localScale = _startSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            HelthMinus();
        }

    }

    private float YPosSetter()
    {
        return Random.Range(20f, ToiletPaperSpawner.HeightSpawn);
    }
}
