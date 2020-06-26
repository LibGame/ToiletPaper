using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

    public static bool sceneEnd;
    public float fadeSpeed = 1.5f;
    public int nextLevel = 1;
    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
        sceneEnd = false;
    }

    void Update()
    {
        if (sceneEnd)
        {
            EndScene();
        }
    }

    void EndScene()
    {
        _image.enabled = true;
        _image.color = Color.Lerp(_image.color, Color.black, fadeSpeed * Time.deltaTime);

        if (_image.color.a >= 0.95f)
        {
            SceneManager.LoadScene("GameScence");
        }
    }
}
