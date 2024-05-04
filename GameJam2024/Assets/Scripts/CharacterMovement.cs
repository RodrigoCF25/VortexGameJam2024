using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)] public float movementSpeed = 5.0f;
    private float horizontalInput = 0.0f;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    // Referencia al objeto que maneja la dirección de mirada del personaje
    private CharacterChecks characterChecks;

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
        horizontalInput = Input.GetAxis("Horizontal");

        // Setea la dirección de mirada del personaje
        if(horizontalInput != 0)
        {
            characterChecks.SetCharacterWatchingRight(horizontalInput > 0);
        }

        // Mueve al personaje horizontalmente
        transform.position += Vector3.right * horizontalInput *  Time.deltaTime * movementSpeed;

        // Voltea el Sprite Renderer basado en la dirección de mirada
        _spriteRenderer.flipX = characterChecks.IsWatchingRight() ? false : true;
    }
}
