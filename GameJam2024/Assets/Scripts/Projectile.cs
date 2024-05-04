using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rigidbody;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float lifeTime = 5f;

    Vector2 shootingDirection = Vector2.right;


    CharacterChecks _characterChecks;

    void Awake()
    {
        _characterChecks = CharacterChecks.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnScene()
    {

        shootingDirection = _characterChecks.IsWatchingRight() ? Vector2.right : Vector2.left;
        transform.Rotate(0f, _characterChecks.IsWatchingRight() ? 0f : 180f, 0f);
        _rigidbody.velocity = shootingDirection * speed;
        StartCoroutine(ProjectileLifeTime());
    }

    IEnumerator ProjectileLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D() 
    {
        gameObject.SetActive(false);
    }
}
