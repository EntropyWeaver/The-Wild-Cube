using UnityEngine;
using System.Collections;

public class MusicStarter : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject buttonToHide;
    public MusicVisualizerManager visualizerManager;

    // Este es el método que debe llamar tu botón
    public void OnStartButtonClicked()
    {
        StartCoroutine(StartMusicCoroutine());
    }

    private IEnumerator StartMusicCoroutine()
    {
        // 1) Carga el clip en memoria (necesario en WebGL)
        if (audioSource.clip.loadState != AudioDataLoadState.Loaded)
        {
            audioSource.clip.LoadAudioData();
            yield return new WaitUntil(() =>
                audioSource.clip.loadState == AudioDataLoadState.Loaded);
        }

        // 2) Reproduce y oculta el botón
        audioSource.Play();
        buttonToHide.SetActive(false);

        // 3) Espera un frame para que el audio realmente empiece
        yield return null;

        // 4) Inicializa el visualizador
        visualizerManager.Initialize();
    }
}
