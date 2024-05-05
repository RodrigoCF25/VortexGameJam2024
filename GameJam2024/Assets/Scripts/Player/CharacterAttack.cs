using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    public CharacterChecks _characterChecks;

    public GameObject attackHitBox;
    public bool isAttacking = false;
    public bool canAttack = true;
    public float attackCooldown = 0.5f;

    public delegate void AttackEvent(bool isAttacking);
    public static event AttackEvent OnAttackEvent;


    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        isAttacking = false;
        DeactiveAttackHitBox();
    }

    // Update is called once per frame
    void Update()
    {   
        Attack();
    }


    public void Attack()
    {
        if(_characterChecks.IsKeyBoardInputAllowded() && Input.GetKeyDown(KeyCode.L) && canAttack)
        {
            ActiveAttackHitBox();
            isAttacking = true;
            OnAttackEvent?.Invoke(isAttacking);
            StartCoroutine(AttackCooldown());
        }
    }


    private void ActiveAttackHitBox()
    {
        attackHitBox.SetActive(true);
    }

    private void DeactiveAttackHitBox()
    {
        attackHitBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
    }


    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        OnAttackEvent?.Invoke(isAttacking);
        canAttack = true;
        DeactiveAttackHitBox();
    }

}
