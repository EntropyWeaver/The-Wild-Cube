using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;       // A qué orbitar (p.ej. VisualizerManager)
    public float distance = 10f;   // Qué tan lejos gira la cámara
    public float height = 2f;      // Altura de la cámara
    public float speed = 20f;      // Velocidad de rotación

    private float angle = 0f;

    void Update()
    {
        if (target == null) return;

        angle += speed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Sin(rad) * distance, height, Mathf.Cos(rad) * distance);
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}
