using System.Collections;
using UnityEngine;

public class TemporaryAudioSource : MonoBehaviour
{
    /// <summary>
    /// �ꎞ�I�ɐ������AAudioClip���Đ����I���������ł���
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
