using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChecks : MonoBehaviour
{

    [SerializeField]
    public LayerMask groundMask;
    private Rigidbody2D _rigidbody;
    public bool characterWatchingRight = true;
    private SpriteRenderer _spriteRenderer;

    #region Singleton
    public static  CharacterChecks Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CharacterMovement.OnCharacterMoveEvent += SetCharacterWatchingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position,Vector2.down * 0.9f,Color.red);
    }

    public bool IsOnGround()
    {
        // Chequear si el jugador está en el suelo usando un Raycast
        return Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundMask);

    }

    public bool IsWatchingRight()
    {
        return characterWatchingRight;
    }


    public void SetCharacterWatchingDirection()
    {
        if (Input.GetAxis("Horizontal") > 0 && !characterWatchingRight)
        {
            characterWatchingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0 && characterWatchingRight)
        {
            characterWatchingRight = false;
            transform.Rotate(0f, 180f, 0f);
            
        }
    }

    




}
