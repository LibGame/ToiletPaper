using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuePaperScipt : MonoBehaviour
{
    private MenuePaperSpawner _spawner;
    private bool _isCanSpawn = true;

    void Start()
    {
        _spawner = GameObject.Find("Play").GetComponent<MenuePaperSpawner>();
    }

    void Update()
    {

        if (transform.position.y <= 0.92f && _isCanSpawn != false)
        {
            _spawner.SpawnPaper();
            _isCanSpawn = false;
        }

        if (transform.position.y <= -9f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5f);

        }
        
    }
}
