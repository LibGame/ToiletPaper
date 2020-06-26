using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public static bool sceneEnd;
    public float fadeSpeed = 1.5f;
    private Image _image;
    private bool sceneStarting;
    public GameObject canvass;

    void Awake()
    {
        _image = GetComponent<Image>();
        _image.enabled = true;
        sceneStarting = true;
        sceneEnd = false;
    }

    void Update()
    {
        if (sceneStarting) StartScene();
    }

    void StartScene()
    {
        _image.color = Color.Lerp(_image.color, Color.clear, fadeSpeed * Time.deltaTime);

        if (_image.color.a <= 0.05f)
        {
            _image.color = Color.clear;
            _image.enabled = false;
            sceneStarting = false;
            canvass.SetActive(false);

        }
    }
}
