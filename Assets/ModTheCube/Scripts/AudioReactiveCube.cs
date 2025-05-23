using UnityEngine;
/// Este componente solo recibe el espectro desde fuera (UpdateVisual), no necesita un AudioSource propio.
public class AudioReactiveCube : MonoBehaviour
{
    public int bandIndex;
    public AudioSource audioSource;

    private Material _material;
    private Vector3 baseScale;
    private int totalBands;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        baseScale = transform.localScale;
        _material.EnableKeyword("_EMISSION");

        // Asumimos que el manager nos pasa spectrum.Length
        totalBands = FindFirstObjectByType<MusicVisualizerManager>().numberOfCubes;
    }

    public void UpdateVisual(float[] spectrum)
    {
        if (_material == null) return;
        if (bandIndex >= spectrum.Length) return;

        float intensity = Mathf.Clamp(spectrum[bandIndex] * 100f, 0.1f, 10f);
        float emissionStrength = Mathf.Clamp(intensity * 0.2f + 0.1f, 0.1f, 2.5f);

        // Escala vertical
        float scaleY = Mathf.Lerp(transform.localScale.y, baseScale.y + intensity, Time.deltaTime * 8f);
        transform.localScale = new Vector3(baseScale.x, scaleY, baseScale.z);

        // Color arcoíris correctamente mapeado a todas las bandas
        Color baseColor = Color.HSVToRGB((float)bandIndex / (totalBands - 1), 0.8f, 0.9f);
        _material.color = baseColor;

        // Emisión con halo
        _material.SetColor("_EmissionColor", baseColor * emissionStrength);
    }
}
