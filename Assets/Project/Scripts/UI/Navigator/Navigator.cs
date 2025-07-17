using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void GamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public static void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
