using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMovesDown : MonoBehaviour
{

    private Vector3 _startPos = new Vector3(-1.75f, 12.14f, 0);
    public bool _isStopedGame;

    private void Update()
    {
        if(_isStopedGame != true)
        {
            if (transform.position.y <= -14.6f)
            {
                transform.position = _startPos;
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * ToiletPaperSpawner.paperSpeed);

            }
        }
    }

}
