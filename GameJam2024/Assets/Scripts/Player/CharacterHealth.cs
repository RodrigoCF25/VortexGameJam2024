using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{

    [SerializeField][Range(1,3)] public byte playerCurrentHealth = 3;
    [SerializeField][Range(1,3)] public byte playerMaxHealth = 3;

    public delegate void OnHealthChangedDelegate(byte currentHealth);
    public static event OnHealthChangedDelegate OnHealthChangedEvent;

    public delegate void OnTakeDamageDelegate(bool hasReceivedDamage);
    public static event OnTakeDamageDelegate OnTakingDamage;


    public delegate void OnDieDelegate();
    public static event OnDieDelegate OnDie;

    public bool invulnerable = false;
    public float invulnerableTime = 1.0f;

    public bool hasReceivedDamage = false;
    public float receiveDamageTime = 0.5f;
    public float dyingTime = 3.0f;

    private CharacterChecks _characterChecks;

    void Start() 
    {
        _characterChecks = GameObject.Find("Player").GetComponent<CharacterChecks>();
        playerCurrentHealth = playerMaxHealth;
        hasReceivedDamage = false;
        invulnerable = false;
    }

    void Update()
    {
        if (_characterChecks.IsKeyBoardInputAllowded() && Input.GetKeyDown(KeyCode.O))
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
        OnTakeDamage();
        if (playerCurrentHealth == 0)
        {

            Die();
        }
        else
        {
            StartCoroutine(Invulnerable());
        }
    }

    public void OnTakeDamage()
    {
        hasReceivedDamage = true;
        OnTakingDamage?.Invoke(hasReceivedDamage);
        StartCoroutine(ReceiveDamage());
    }

    public void Die()
    {
        StartCoroutine(Dying());
    }

    IEnumerator Invulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }

    IEnumerator Dying()
    {
        //el usuario ya no tiene input
        _characterChecks.SetKeyBoardInput(false);
        yield return new WaitForSeconds(receiveDamageTime);
        OnDie?.Invoke();
        yield return new WaitForSeconds(dyingTime);
        
    }

    IEnumerator ReceiveDamage()
    {
        yield return new WaitForSeconds(0.5f);
        hasReceivedDamage = false;
        OnTakingDamage?.Invoke(hasReceivedDamage);
    }

    void OnDestroy()
    {
        OnHealthChangedEvent = null;
        OnTakingDamage = null;
        OnDie = null;
    }

    
}
