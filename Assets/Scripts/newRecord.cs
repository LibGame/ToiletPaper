using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class newRecord : MonoBehaviour
{

    private Coroutine _recordCoroutine;
    public UnityEvent eventExplosion;
    private bool isExplosion = true;

    public void StartRecord()
    {
        _recordCoroutine = StartCoroutine(RecordDown());
    }
    private bool isDown;

    public IEnumerator RecordDown()
    {

        while (true)
        {

            if(transform.position.y >= 3.4f && isDown != true)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 3f);
            }
            else
            {
                isDown = true;
                if (isExplosion)
                {
                    eventExplosion.Invoke();
                    isExplosion = false;
                }
                transform.Translate(Vector3.up * Time.deltaTime * 1f);
                if (transform.position.y >= 8f)
                {
                    Destroy(gameObject);
                }
            }

            yield return new WaitForSeconds(0.0002f);

        }
    }


}
