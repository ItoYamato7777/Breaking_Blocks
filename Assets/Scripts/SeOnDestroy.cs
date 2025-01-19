using UnityEngine;

public class SeOnDestroy : MonoBehaviour
{
    /// <summary>
    /// �I�u�W�F�N�g��Destroy����鎞�AaudioClip���Đ�����
    /// </summary>
    public AudioClip audioClip;
    public float volumeOffset = 1f;

    public GameObject temporaryAudioSource;

    bool isQuited = false;

    void OnApplicationQuit()
    {
        //�G�f�B�^��̃v���C���I��������A������擾����
        isQuited = true;
    }

    void OnDestroy()
    {
        //�G�f�B�^��̃v���C���I���������Destroy���Ăяo����邪�A���̎��͎��s���Ȃ�
        if (!isQuited)
        {
            //�V����AudioSource�𐶐����A������g���ĉ����Đ�����
            GameObject _temporaryAudioSource = Instantiate(temporaryAudioSource, this.transform.position, Quaternion.identity);
            TemporaryAudioSource script = _temporaryAudioSource.GetComponent<TemporaryAudioSource>();
            script.volumeOffset = volumeOffset;
            script.audioClip = audioClip;
        }
    }
}
