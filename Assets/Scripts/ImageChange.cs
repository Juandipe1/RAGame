using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public float velocidadCambio = 1.0f;  // Velocidad de cambio de tamaño y posición de la imagen
    public float tamañoMinimo = 0.5f;  // Tamaño mínimo al que se encojerá la imagen
    public float delayInicial = 5.0f;  // Tiempo de espera antes de comenzar el cambio de tamaño y posición

    private Image imagen;
    private Vector3 tamañoInicial;
    private Vector3 nuevaPosicion;
    private float tiempoTranscurrido = 0.0f;
    private bool comenzarCambio = false;

    void Start()
    {
        imagen = GetComponent<Image>();
        tamañoInicial = transform.localScale;

        // Calcular la nueva posición en la esquina superior derecha
        nuevaPosicion = new Vector3(Screen.width, Screen.height, 0);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        // Espera el tiempo especificado antes de comenzar el cambio de tamaño y posición
        if (tiempoTranscurrido >= delayInicial && !comenzarCambio)
        {
            comenzarCambio = true;
            tiempoTranscurrido = 0.0f;
        }

        // Cambiar el tamaño y la posición de la imagen gradualmente
        if (comenzarCambio)
        {
            transform.localScale -= Vector3.one * velocidadCambio * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidadCambio * Time.deltaTime);

            // Si alcanza el tamaño mínimo, detiene el cambio de tamaño y posición
            if (transform.localScale.x <= tamañoInicial.x * tamañoMinimo)
            {
                comenzarCambio = false;
            }
        }
    }
}
