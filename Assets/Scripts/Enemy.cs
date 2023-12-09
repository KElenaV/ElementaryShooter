using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

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
            projectile.Destroy();
        }

        gameObject.SetActive(false);
    }
}
