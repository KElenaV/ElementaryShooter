using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _gameOverScore;

    private int _score;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
            enemy.GameOver += OnGameOver;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
            enemy.GameOver -= OnGameOver;
        }
    }

    private void OnEnemyDied()
    {
        _score++;
        _scoreDisplay.text = $"Score: {_score}";
    }

    private void OnGameOver()
    {
        _gameOverPanel.SetActive(true);
        _gameOverScore.text = $"Score: {_score}";
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit() => Application.Quit();
}
