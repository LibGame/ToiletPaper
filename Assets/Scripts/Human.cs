using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Human : MonoBehaviour
{
    private Animator _animator;
    private Camera _camera;
    private Coroutine _cameraCoroutine;
    public Transform ToiletPaperFutlar;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _camera = Camera.main;
    }

     

    private void IsSiting()
    {
        _animator.SetBool("isSiting", true);
        _cameraCoroutine = StartCoroutine(CameraChange());
        Invoke("StartGame", 0.5f);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScence");
    }

    private IEnumerator CameraChange()
    {

        while (true)
        {
            _camera.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, 2, 4f * Time.deltaTime);
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, ToiletPaperFutlar.position, 10f * Time.deltaTime);
            yield return new WaitForSeconds(0.02f);

        }
    }
}
