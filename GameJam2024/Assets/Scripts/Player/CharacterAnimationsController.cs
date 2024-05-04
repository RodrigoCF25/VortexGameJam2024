using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsController : MonoBehaviour
{

    private Animator _animator;
    
    private CharacterChecks _characterChecks;


    void Awake()
    {
        _characterChecks = CharacterChecks.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        CharacterMovement.OnCharacterMoveEvent += SetSpeedCondition;
        CharacterChecks.OnGroundEvent += SetIsOnGroundCondition;
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


}
