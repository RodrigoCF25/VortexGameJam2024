using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChecks : MonoBehaviour
{

    [SerializeField]
    public LayerMask groundMask;
    private Rigidbody2D _rigidbody;
    public volatile bool isOnGround = false;
    public volatile bool characterWatchingRight = true;
    private SpriteRenderer _spriteRenderer;

    public bool allowKeyBoardInput = true;


    //For the animator script
    public delegate void OnGround(bool isOnGround);
    public static event OnGround OnGroundEvent;


    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CharacterMovement.OnCharacterMoveEvent += SetCharacterWatchingDirection;
        groundMask = LayerMask.GetMask("Ground");
        allowKeyBoardInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position,Vector2.down * 0.8f,Color.red);
        IsOnGround();
    }

    public bool IsOnGround()
    {
        // Chequear si el jugador está en el suelo usando un Raycast
        isOnGround = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundMask);
        
        OnGroundEvent?.Invoke(isOnGround);

        return isOnGround;  

    }

    public bool IsWatchingRight()
    {
        return characterWatchingRight;
    }


    public void SetCharacterWatchingDirection(float horizontalInputMovement)
    {
        if (horizontalInputMovement > 0 && !characterWatchingRight)
        {
            characterWatchingRight = true;
            if(this)
            {
                this.transform.Rotate(0f, 180f, 0f);
            }
        }
        else if (horizontalInputMovement < 0 && characterWatchingRight)
        {
            characterWatchingRight = false;
            if(this)
            {
            this.transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    public void SetKeyBoardInput(bool allowKeyBoardInput)
    {
        this.allowKeyBoardInput = allowKeyBoardInput;
    }
    
    public bool IsKeyBoardInputAllowded()
    {
        return allowKeyBoardInput;
    }

    public void StopTime(bool stopTime)
    {
        Time.timeScale = stopTime ? 0 : 1;
    }


    void OnDestroy()
    {
        CharacterMovement.OnCharacterMoveEvent -= SetCharacterWatchingDirection;
    }


}
