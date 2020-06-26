using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Color CollorStay;
    public Text ObjectColor;

    private void Start()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (true)
        {
            ObjectColor.color = Color.Lerp(ObjectColor.color, CollorStay, Time.deltaTime);

            if(ObjectColor.color.a < 0.1)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
