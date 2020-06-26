using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private Interface inter;

    private void Start()
    {
        inter = GameObject.Find("Interface").GetComponent<Interface>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blot")
        {
            inter.HelthMinus(true);
            Blot blot = collision.gameObject.GetComponent<Blot>();
            blot.ChangePosition();
        }
        if (collision.gameObject.tag == "MonsterBlot")
        {
            inter.HelthMinus(true);
            MonsterBlot blot = collision.gameObject.GetComponent<MonsterBlot>();
            blot.ChangePosition();
        }
        if (collision.gameObject.tag == "DoublPepper")
        {
            inter.HelthMinus(false);
            DoublePapaer blot = collision.gameObject.GetComponent<DoublePapaer>();
            blot.ChangePosition();
        }
    }
}
