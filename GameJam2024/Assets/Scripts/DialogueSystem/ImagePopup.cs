using UnityEngine;

public class ImagePopup : MonoBehaviour
{
    [SerializeField] private GameObject imagePrefab; // Referencia al prefab de la imagen
    [SerializeField] private Vector3 imagePosition; // Posición de la imagen emergente

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // Verificar si la colisión es con el jugador
        {
            ShowImagePopup(); // Mostrar la imagen emergente
        }
    }

    void ShowImagePopup()
    {
        GameObject imageInstance = Instantiate(imagePrefab, transform.position + imagePosition, transform.rotation); // Crear una instancia del prefab de la imagen
        // Opcional: Agregar lógica para ajustar la posición o escala de la imagen
    }
}

