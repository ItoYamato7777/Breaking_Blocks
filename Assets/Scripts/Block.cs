using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.2f;   // 揺れる時間
    [SerializeField] private float shakeMagnitude = 0.3f; // 揺れの大きさ
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Main Camera にアタッチされている CameraShaker を取得
        CameraShaker shaker = Camera.main.GetComponent<CameraShaker>();
        if (shaker != null)
        {
            // カメラを揺らす
            shaker.CameraShake(shakeDuration, shakeMagnitude);
        }
        Destroy(this.gameObject);
    }
}
