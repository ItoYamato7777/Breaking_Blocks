using UnityEngine;

public class SeOnDestroy : MonoBehaviour
{
    /// <summary>
    /// オブジェクトがDestroyされる時、audioClipを再生する
    /// </summary>
    public AudioClip audioClip;
    public float volumeOffset = 1f;

    public GameObject temporaryAudioSource;

    bool isQuited = false;

    void OnApplicationQuit()
    {
        //エディタ上のプレイが終わった時、それを取得する
        isQuited = true;
    }

    void OnDestroy()
    {
        //エディタ上のプレイが終わった時にDestroyが呼び出されるが、その時は実行しない
        if (!isQuited)
        {
            //新しいAudioSourceを生成し、それを使って音を再生する
            GameObject _temporaryAudioSource = Instantiate(temporaryAudioSource, this.transform.position, Quaternion.identity);
            TemporaryAudioSource script = _temporaryAudioSource.GetComponent<TemporaryAudioSource>();
            script.volumeOffset = volumeOffset;
            script.audioClip = audioClip;
        }
    }
}
