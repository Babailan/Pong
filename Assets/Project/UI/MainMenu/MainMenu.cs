using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
