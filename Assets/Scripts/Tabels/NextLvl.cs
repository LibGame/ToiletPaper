
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLvl : MonoBehaviour
{
    public GameObject WinTable;

    public void GoToNextLvl()
    {
        SceneManager.LoadScene("GameScence");
        Destroy(WinTable);
    }
}
