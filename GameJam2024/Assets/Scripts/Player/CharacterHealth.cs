using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{

    [SerializeField][Range(1,3)] public byte playerCurrentHealth = 3;
    [SerializeField][Range(1,3)] public byte playerMaxHealth = 3;

    public delegate void OnHealthChangedDelegate(byte currentHealth);
    public static event OnHealthChangedDelegate OnHealthChangedEvent;

    public delegate void OnTakeDamageDelegate();
    public static event OnTakeDamageDelegate OnTakinDamage;


    public delegate void OnDieDelegate();
    public static event OnDieDelegate OnDie;

    public bool invulnerable = false;

    private CharacterChecks _characterChecks;

    void Start() 
    {
        _characterChecks = GameObject.Find("Player").GetComponent<CharacterChecks>();
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        if (_characterChecks.IsKeyBoardInputAllowded() && Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(byte damage)
    {
        if(invulnerable)
        {
            return;
        }

        playerCurrentHealth -= damage;
        OnHealthChangedEvent?.Invoke(playerCurrentHealth);
        if (playerCurrentHealth == 0)
        {
            Die();
        }
        else
        {
            OnTakeDamage();
        }
    }

    public void OnTakeDamage()
    {
        // Implementa acciones adicionales cuando el personaje recibe daño
    }

    public void Die()
    {
        StartCoroutine(Dying());
    }

    IEnumerator Invulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(1.0f);
        invulnerable = false;
    }

    IEnumerator Dying()
    {
        //el usuario ya no tiene input
        _characterChecks.SetKeyBoardInput(false);
        OnDie?.Invoke();
        yield return new WaitForSeconds(3.0f);
        
    }


    void OnDestroy()
    {
        OnHealthChangedEvent = null;
        OnTakinDamage = null;
        OnDie = null;
    }

    
}
