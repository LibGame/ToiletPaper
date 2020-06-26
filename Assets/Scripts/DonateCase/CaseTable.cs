using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseTable : MonoBehaviour
{
    public Sprite[] things;
    public Image[] ImageDrop;

    private void Start()
    {
        SetThings();
    }

    public void SetThings()
    {
        for(int i = 0; i < things.Length; i++)
        {
            ImageDrop[i].sprite = things[i];
        }
    }

}
