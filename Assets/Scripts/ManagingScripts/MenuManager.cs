using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Loading");
    }
    
    public void Quit(bool isQuitWithError = false)
    {
        Application.Quit();
    }
}
