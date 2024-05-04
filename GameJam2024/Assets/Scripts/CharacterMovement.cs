using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    [Range(1.0f, 10.0f)] public float movementSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacterHorizontally();
        
    }


    void MoveCharacterHorizontally()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") *  Time.deltaTime * movementSpeed;
    }

    

}
