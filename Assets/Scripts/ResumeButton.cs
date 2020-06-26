
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        SceneManager.LoadScene("GameScence");
    }
}
