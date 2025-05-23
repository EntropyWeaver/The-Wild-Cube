using UnityEngine;
using System.Linq;

public class MusicVisualizerManager : MonoBehaviour
{
    private bool initialized = false;
    public GameObject cubePrefab;
    public AudioSource audioSource;
    public int numberOfCubes = 64;
    public float radius = 10f;

    private GameObject[] cubes;
    private float[] spectrum;

    void Start()
    {
        if (audioSource == null)
            audioSource = GameObject.Find("MusicController").GetComponent<AudioSource>();
        spectrum = new float[1024];

  
    }

    void Update()
    {
        if (!initialized || !audioSource.isPlaying) return;
        Debug.Log("Visualizer UpdateVisual()");
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] != null)
                cubes[i].GetComponent<AudioReactiveCube>()?.UpdateVisual(spectrum);
        }
    }

    public void Initialize()
    {   
        Debug.Log("Visualizer Initialize()");
        spectrum = new float[1024];
        cubes = new GameObject[numberOfCubes];

        for (int i = 0; i < numberOfCubes; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfCubes;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

            GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity, this.transform);
            cube.transform.LookAt(transform.position);
            cube.name = $"BandCube_{i}";

            AudioReactiveCube arc = cube.GetComponent<AudioReactiveCube>();
            arc.bandIndex = i;
            arc.audioSource = audioSource;

            cubes[i] = cube;
        }
        
        initialized = true;
    }


}
