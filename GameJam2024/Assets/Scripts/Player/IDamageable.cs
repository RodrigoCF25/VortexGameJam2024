using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamageable 
{
    void TakeDamage(byte damage);
    void OnTakeDamage();
    void Die();
}

