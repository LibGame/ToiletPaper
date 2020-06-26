using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Congratilation : MonoBehaviour
{
    public UnityEvent _event;
    private Text _text;
    private Color colorNot = new Color(35,185,255,0);

    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        SpawnCongratilation();
        int rndAngle = Random.Range(-30, 30);
        transform.Rotate(0, 0, rndAngle);

        Invoke("StartCoroutin", 1.5f);
    }

    public void SpawnCongratilation()
    {
        int rnd = Random.Range(1, 100);
        if(rnd >= 1 && rnd <= 40)
        {
            _text.text = "WoW";

        }
        else if (rnd >= 40 && rnd <= 60)
        {
            _text.text = "GOOD";

        }
        else if (rnd >= 70 && rnd <= 90)
        {
            _text.text = "PERFECT";

        }
        else if (rnd >= 90 && rnd <= 100)
        {
            _text.text = "IMPOSSIBLE";

        }
    }

    private void StartCoroutin()
    {
        StartCoroutine(RecordDown());
    }

    public IEnumerator RecordDown()
    {

        while (true)
        {
            _text.color = Color.Lerp(_text.color, colorNot, Time.deltaTime * 2);

            if(_text.color.a > 3f)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.02f);

        }
    }

}
