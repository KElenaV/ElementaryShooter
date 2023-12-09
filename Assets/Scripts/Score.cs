using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void OnEnemyDied()
    {
        _score++;
        _scoreDisplay.text = $"Score: {_score}";
    }
}
