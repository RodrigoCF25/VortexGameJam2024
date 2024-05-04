using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public byte proyectilesRemaining = 3;
    public float rechargeTime = 0.5f;
    private Vector2 shootingDirection = Vector2.right;
    public bool canShoot = true;
    public float reactivateShootingTime = 0.5f;

    private GameObject shootingSpawn;
    private CharacterChecks _characterChecks;

    void Start()
    {
        shootingSpawn = GameObject.Find("ShootingSpawn");
        _characterChecks = CharacterChecks.Instance;
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.F))
        {
            Shoot();
        }
        
    }

    IEnumerator ReactivateShooting()
    {
        yield return new WaitForSeconds(reactivateShootingTime);
        canShoot = true;
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(rechargeTime);
        proyectilesRemaining = 6;
    }

    public void Shoot()
    {
        if (canShoot && proyectilesRemaining > 0)
        {
            GameObject projectile = ObjectPooler.Instance.SpawnFromPool("Bullet", shootingSpawn.transform.position , projectilePrefab.transform.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.OnScene(_characterChecks.IsWatchingRight() ? Vector2.right : Vector2.left);
            proyectilesRemaining--;
            canShoot = false;
            StartCoroutine(ReactivateShooting());
        }
        else if (proyectilesRemaining == 0)
        {
            StartCoroutine(Recharge());
        }
    }





    
}
