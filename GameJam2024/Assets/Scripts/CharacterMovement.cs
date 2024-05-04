using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)] public float movementSpeed = 5.0f;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    // Referencia al objeto que maneja la dirección de mirada del personaje
    private CharacterChecks characterChecks;
    

    public delegate void OnCharacterMove();
    public static event OnCharacterMove OnCharacterMoveEvent;


    void Start()
    {
        // Obtener la instancia de CharacterChecks
        characterChecks = CharacterChecks.Instance;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveCharacterHorizontally();
    }

    void MoveCharacterHorizontally()
    {

        OnCharacterMoveEvent?.Invoke();
        // Mueve al personaje horizontalmente
        transform.position += Vector3.right * Input.GetAxis("Horizontal") *  Time.deltaTime * movementSpeed;

        
        
    }
}
