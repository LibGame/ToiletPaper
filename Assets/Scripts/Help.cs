using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject HelpImg;
    public GameObject Parent;


    public void HelpSpawn()
    {
        var img = Instantiate(HelpImg, HelpImg.transform.position, Quaternion.identity);
        img.transform.SetParent(Parent.transform, false);
    }

}
