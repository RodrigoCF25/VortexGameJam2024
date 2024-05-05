using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    public UnityEvent Interaction; // Evento que se activa al interactuar
    public bool playerHasInteractWithMe = false;

    private void Start()
    {
        playerHasInteractWithMe=false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !playerHasInteractWithMe) // Verificar si la colisión es con el jugador
        {
            Interaction.Invoke(); // Activar el evento de interacción
            Debug.Log("si");
            playerHasInteractWithMe=true;
        }
        
    }
}
