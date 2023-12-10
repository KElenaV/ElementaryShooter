using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private ParticleSystem _burst;
    [SerializeField] private AudioSource _audio;

    public event UnityAction Died;
    public event UnityAction GameOver;

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown() 
        => transform.Translate(Vector2.down * _speed * Time.deltaTime);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Projectile projectile))
        {
            Died?.Invoke();
            projectile.Destroy();
            _burst.gameObject.transform.position = transform.position;
            _burst.Play();
            _audio.Play();
        }

        if(collision.gameObject.TryGetComponent(out Player player) ||
           collision.gameObject.TryGetComponent(out BottomDestroyer destroyer))
        {
            GameOver?.Invoke();
        }

        gameObject.SetActive(false);
    }

}
