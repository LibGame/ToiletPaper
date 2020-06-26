using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    public string Scence;

    public void SetScence()
    {
        SceneManager.LoadScene(Scence, LoadSceneMode.Additive);

    }
}
