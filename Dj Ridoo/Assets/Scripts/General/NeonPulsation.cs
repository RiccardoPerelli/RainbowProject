using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonPulsation : MonoBehaviour
{

    public float pulsationSpeed = 1f;
    public float amplitude = 3f;

    Material neonMaterial;
    Color neonColor;

    private float index = 0f;
    private GameObject[] instruments;

    // Start is called before the first frame update
    void Start()
    {
        neonMaterial = GetComponent<Renderer>().material;
        neonColor = neonMaterial.color;
        instruments = GameObject.FindGameObjectsWithTag("Instrument");
        pulsationSpeed = instruments.Length + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //neonColor = neonMaterial.color;
        instruments = GameObject.FindGameObjectsWithTag("Instrument");
        pulsationSpeed = instruments.Length + 1;
        index += Time.deltaTime;
        neonMaterial.SetColor("_EmissionColor", neonColor * Mathf.Sin(index * pulsationSpeed) * amplitude);
    }
}
