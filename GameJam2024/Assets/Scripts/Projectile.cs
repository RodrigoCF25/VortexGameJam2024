using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rigidbody;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float lifeTime = 5f;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnScene(Vector2 shootingDirection)
    {
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
