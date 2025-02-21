using System.Collections;
using UnityEngine;

public class TemporaryAudioSource : MonoBehaviour
{
    /// <summary>
    /// 一時的に生成し、AudioClipを再生し終わったら消滅する
    /// </summary>
    public AudioClip audioClip;
    public float volumeOffset = 1f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = audioSource.volume * volumeOffset;
        audioSource.PlayOneShot(audioClip);
        StartCoroutine(PlayingMonitor());
    }

    IEnumerator PlayingMonitor()
    {
        while (true) {
            yield return null;
            if (!audioSource.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
