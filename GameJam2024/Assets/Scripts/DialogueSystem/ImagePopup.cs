using UnityEngine;

public class ImagePopup : MonoBehaviour
{
    [SerializeField] private GameObject imagePrefab; // Referencia al prefab de la imagen
    [SerializeField] private Vector3 imagePosition; // Posici�n de la imagen emergente

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // Verificar si la colisi�n es con el jugador
        {
            ShowImagePopup(); // Mostrar la imagen emergente
        }
    }

    void ShowImagePopup()
    {
        GameObject imageInstance = Instantiate(imagePrefab, transform.position + imagePosition, transform.rotation); // Crear una instancia del prefab de la imagen
        // Opcional: Agregar l�gica para ajustar la posici�n o escala de la imagen
    }
}

