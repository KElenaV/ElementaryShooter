using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Projectile[] _projectiles;
    [SerializeField] private AudioSource _audio;

    private PlayerInput _input;
    private float _xBoard = 8f;
    private float _yBoard = 4f;
    private float _shootDelay = 0.9f;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();

        foreach (var projectile in _projectiles)
        {
            projectile.gameObject.SetActive(false);
        }

        StartCoroutine(Shoot());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_input.Movement * _speed * Time.deltaTime);
        transform.position = new Vector2(
            SetBoards(transform.position.x, _xBoard),
            SetBoards(transform.position.y, _yBoard));
    }

    private float SetBoards(float position, float board)
        => Mathf.Clamp(position, -board, board);

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootDelay);
            var projectile = _projectiles.FirstOrDefault(p => p.gameObject.activeSelf == false);

            if (projectile != null)
            {
                projectile.gameObject.SetActive(true);
                projectile.transform.position = _shootPoint.position;
                _audio.Play();
            }
        }
    }
}
