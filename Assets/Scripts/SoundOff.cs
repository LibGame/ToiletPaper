using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOff : MonoBehaviour
{

    public Sprite off;
    public Sprite on;
    public Image img;
    private bool isOff;
    private AudioSource music;

    void Start()
    {
        music = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    public void MusicChange()
    {
        if(isOff != true)
        {
            img.sprite = off;
            isOff = true;
            music.Pause();
        }else if (isOff)
        {
            img.sprite = on;
            isOff = false;
            music.Play();
        }
    }

}
