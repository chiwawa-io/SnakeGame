using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance  { get; private set; }

    private int _currentScore;

    public static Action<int> OnGameOver;
    
    private int _errorCode;
    private string _errorMessage;

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
        
        Player.UpdateScore += UpdateScore;
    }
    private void OnDisable()
    {
        Player.UpdateScore -= UpdateScore;
    }

    void UpdateScore(int lengthOfSnake, Vector2 position)
    {
        _currentScore +=  lengthOfSnake*100;
        GameUI.Instance.UpdateScoreText(_currentScore);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(_currentScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ReloadGame()
    {
        SceneManager.LoadScene("Loading");
    }

    void ForceQuit()
    {
        Quit();
    }

    public void Quit(bool isQuitWithError = false)
    {
        Application.Quit();
    }
}
