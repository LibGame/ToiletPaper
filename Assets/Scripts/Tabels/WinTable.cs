using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTable : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        canvas.worldCamera = Camera.main;
        canvas.sortingLayerName = "Buttons";
    }
}
