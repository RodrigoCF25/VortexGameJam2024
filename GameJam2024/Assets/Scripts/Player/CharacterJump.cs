using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{

    [SerializeField]
    private CharacterChecks _characterChecks;
    private Rigidbody2D _rigidbody;

    [SerializeField]
    [Range(1.0f, 10.0f)] public float jumpForce = 5.0f;
    [Range(1, 3)] public volatile byte maxJumpCount = 2;
    public int jumpCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        _characterChecks = GetComponent<CharacterChecks>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    void Jump()
    {
        if (_characterChecks.IsKeyBoardInputAllowded() &&  Input.GetKeyDown(KeyCode.Space) && (_characterChecks.IsOnGround() || (jumpCount < maxJumpCount)))
        {
            // Incrementar el contador de saltos si no está en el suelo
            if (!_characterChecks.IsOnGround())
            {
                jumpCount++;
            }
            else // Si está en el suelo, reiniciar el contador de saltos
            {
                jumpCount = 1;
            }

            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    


}
