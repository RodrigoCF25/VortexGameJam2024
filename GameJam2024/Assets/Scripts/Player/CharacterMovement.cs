using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)] public float movementSpeed = 5.0f;
    public volatile float horizontalInputMovement;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    // Referencia al objeto que maneja la dirección de mirada del personaje
    private CharacterChecks characterChecks;
    

    public delegate void OnCharacterMove(float horizontalInputMovement);
    public static event OnCharacterMove OnCharacterMoveEvent;


    void Awake()
    {
        characterChecks = CharacterChecks.Instance;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveCharacterHorizontally();
    }

    void MoveCharacterHorizontally()
    {

        horizontalInputMovement = Input.GetAxis("Horizontal");  
        OnCharacterMoveEvent?.Invoke(horizontalInputMovement);
        // Mueve al personaje horizontalmente
        transform.position += Vector3.right * horizontalInputMovement *  Time.deltaTime * movementSpeed;

        
        
    }
}
