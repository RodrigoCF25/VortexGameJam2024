using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChecks : MonoBehaviour
{

    [SerializeField]
    public LayerMask groundMask;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
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


}
