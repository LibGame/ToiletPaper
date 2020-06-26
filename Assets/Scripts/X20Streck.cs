using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X20Streck : MonoBehaviour
{
    private Coroutine _recordCoroutine;
    private bool isDown;


    public void StartStreack()
    {
        _recordCoroutine = StartCoroutine(StreackDown());
    }

    public IEnumerator StreackDown()
    {

        while (true)
        {

            if (transform.position.x <= -1.9f && isDown != true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 3f);
            }
            else
            {
                isDown = true;

                transform.Translate(Vector3.left * Time.deltaTime * 1f);
                if (transform.position.x <= -5f)
                {
                    StopCoroutine(_recordCoroutine);
                }
            }

            yield return new WaitForSeconds(0.0002f);

        }
    }
}
