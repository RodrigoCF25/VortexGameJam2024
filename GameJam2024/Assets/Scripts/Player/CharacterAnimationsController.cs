using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsController : MonoBehaviour
{

    public Animator _animator;
    
    public CharacterChecks _characterChecks;


    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool("isAlive", true);
        _characterChecks = GetComponent<CharacterChecks>();
        CharacterMovement.OnCharacterMoveEvent += SetSpeedCondition;
        CharacterChecks.OnGroundEvent += SetIsOnGroundCondition;
        CharacterHealth.OnDie += ActivateDieAnimation;
        CharacterHealth.OnTakingDamage += HasReceivedDamageAnimation;
        CharacterAttack.OnAttackEvent += SetAttackAnimationStatus;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void SetSpeedCondition(float horizontalInputMovement)
    {
 
        _animator.SetFloat("speed", Mathf.Abs(horizontalInputMovement));
        
    }

    public void SetIsOnGroundCondition(bool isOnGround)
    {

        _animator.SetBool("isOnGround", isOnGround);
        
    }

    public void HasReceivedDamageAnimation(bool hasReceivedDamage)
    {
        _animator.SetBool("hasReceivedDamage",hasReceivedDamage);
    }

    public void ActivateDieAnimation()
    {

        _animator.SetBool("isAlive", false);
        
    }


    public void SetAttackAnimationStatus(bool isAttacking)
    {
        _animator.SetBool("isAttacking", isAttacking);
    }




    void OnDestroy()
    {
        CharacterMovement.OnCharacterMoveEvent -= SetSpeedCondition;
        CharacterChecks.OnGroundEvent -= SetIsOnGroundCondition;
        CharacterHealth.OnDie -= ActivateDieAnimation;
        CharacterAttack.OnAttackEvent -= SetAttackAnimationStatus;
    }

}
