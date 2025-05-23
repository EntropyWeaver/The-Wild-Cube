using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float timer = 0f;
    private Material _material;

    void Start()
    {
        _material = Renderer.material;
        _material.color = new Color(Random.value, Random.value, Random.value, Random.value);
    }

    void Update()
    {
        // rotación
        transform.Rotate(
            Random.Range(100f, 500f) * Time.deltaTime,
            Random.Range(100f, 500f) * Time.deltaTime,
            Random.Range(100f, 500f) * Time.deltaTime
        );

        // cambio de color
        _material.EnableKeyword("_EMISSION");
        _material.SetColor("_EmissionColor", _material.color * 0.5f);

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            _material.color = new Color(Random.value, Random.value, Random.value, 1f);
            timer = 0f;
        }
    }
}