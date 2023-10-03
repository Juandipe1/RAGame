using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class LocationManager : MonoBehaviour

{
    public TMP_Text coordinatesText;

    float latRef = 4.661408f;
    float longRef = -74.059677f;
    // Start is called before the first frame update
    void Start()
    {
        StartLocation();
        coordinatesText.text = "Status" + Input.location.status;
        Input.location.Start();
    }



    // Update is called once per frame

    void Update()
    {
        coordinatesText.text = "Status" + Input.location.status;
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;
            float altitude = Input.location.lastData.altitude;

            float distanciaGrados = Mathf.Sqrt(Mathf.Pow(latitude - latRef, 2) + Mathf.Pow(longitude - longRef, 2));
            float distanciaMetros = distanciaGrados * 40075000 / 360;
            distanciaMetros = Mathf.Round(distanciaMetros);
            coordinatesText.text = "Status: " + Input.location.status + $"\nLatitud: {latitude}\nLongitud: {longitude}\nDistancia: {distanciaMetros}m";
            if (distanciaMetros <= 25)
            {
                coordinatesText.text = "Status: " + Input.location.status + $"\nLatitud: {latitude}\nLongitud: {longitude}\nDistancia: {distanciaMetros}m\nESTÁS CERCA";
            }
            else
            {
                coordinatesText.text = "Status: " + Input.location.status + $"\nLatitud: {latitude}\nLongitud: {longitude}\nDistancia: {distanciaMetros}m\nFRÍO";
            }
        }

    }
    IEnumerator StartLocation()

    {
        // Start location services
        Input.location.Start();
        // Wait for location services to initialize
        while (Input.location.status == LocationServiceStatus.Initializing)
            yield return new WaitForSeconds(1);
        // Get the device's location
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;
            float altitude = Input.location.lastData.altitude;

            coordinatesText.text = $"Latitud: {latitude}\nLongitud: {longitude}\nAltitud {altitude}";
        }
        // Stop location services

    }

}