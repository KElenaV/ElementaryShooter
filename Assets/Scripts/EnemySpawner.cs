using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _xBound = 7f;
    [SerializeField] private float _delay = 1.5f;
    [SerializeField] private Enemy[] _enemies;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Create();
            yield return _waitForSeconds;
        }
    }

    private void Create()
    {
        Enemy enemy = _enemies.FirstOrDefault(e => e.gameObject.activeSelf == false);
        float xPos = Random.Range(-_xBound, _xBound);
        enemy.gameObject.SetActive(true);
        enemy.transform.position = new Vector2(xPos, transform.position.y);
    }

}
