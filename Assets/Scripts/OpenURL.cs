using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{

    public string Link;

    public void OpenSource()
    {
        Application.OpenURL(Link);
    }
}
