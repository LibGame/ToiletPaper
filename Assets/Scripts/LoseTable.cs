using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTable : MonoBehaviour
{

    public Canvas canvas;
    private Vector3 positionTargget = new Vector3(2.36f, 3.63f,1);
    public GameObject IDS;

    void Start()
    {
        canvas.worldCamera = Camera.main;
        canvas.sortingLayerName = "Buttons";

        if (Interface._itWasWin)
        {
            IDS.SetActive(true);
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, positionTargget, Time.deltaTime * 6f);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

}
