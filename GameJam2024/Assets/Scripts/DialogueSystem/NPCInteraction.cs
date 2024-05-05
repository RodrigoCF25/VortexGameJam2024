using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    public UnityEvent Interaction; // Evento que se activa al interactuar

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // Verificar si la colisión es con el jugador
        {
            Interaction.Invoke(); // Activar el evento de interacción
            Debug.Log("si");
        }
        Debug.Log("si");
    }
}
