using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)] public float movementSpeed = 5.0f;
    public volatile float horizontalInputMovement;

    [SerializeField]
    public SpriteRenderer _spriteRenderer;

    // Referencia al objeto que maneja la dirección de mirada del personaje
    public CharacterChecks _characterChecks;
    

    public delegate void OnCharacterMove(float horizontalInputMovement);
    public static event OnCharacterMove OnCharacterMoveEvent;



    void Start()
    {
    }

    void Update()
    {
        MoveCharacterHorizontally();
    }

    void MoveCharacterHorizontally()
    {
        if(_characterChecks.IsKeyBoardInputAllowded())
        {
            horizontalInputMovement = Input.GetAxis("Horizontal");  
            OnCharacterMoveEvent?.Invoke(horizontalInputMovement);
            // Mueve al personaje horizontalmente
            transform.position += Vector3.right * horizontalInputMovement *  Time.deltaTime * movementSpeed;
        }

        
        
    }
    
}
