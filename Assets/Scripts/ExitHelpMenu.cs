using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHelpMenu : MonoBehaviour
{
    public GameObject helpMenu;

    public void DestroyHelpMenu()
    {
        Destroy(helpMenu);
    }
}
