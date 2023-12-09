using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime = 3f;

    private void OnEnable()
    {
        StartCoroutine(RemoveAfterLifetime());
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private IEnumerator RemoveAfterLifetime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
