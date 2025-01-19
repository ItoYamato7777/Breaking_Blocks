using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{
    // カメラの初期位置を保存しておくための変数
    private Vector3 originalPos;

    // Awake() はゲーム開始時に一度だけ呼ばれます
    private void Awake()
    {
        // ゲーム開始時のカメラのローカル座標を記憶
        originalPos = transform.localPosition;
    }

    /// <summary>
    /// カメラを揺らすための公開メソッド
    /// </summary>
    /// <param name="duration">揺れる時間</param>
    /// <param name="magnitude">揺れの大きさ</param>
    public void CameraShake(float duration, float magnitude)
    {
        // コルーチンを開始
        StartCoroutine(Shake(duration, magnitude));
    }

    /// <summary>
    /// 実際にカメラを揺らすコルーチン
    /// </summary>
    private IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // -1 から 1 のランダム値を使ってカメラ位置をランダムにずらす
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(
                originalPos.x + x,
                originalPos.y + y,
                originalPos.z
            );

            elapsed += Time.deltaTime;
            yield return null;  // フレームの終わりまで待機
        }

        // 揺れが終わったら元の位置に戻す
        transform.localPosition = originalPos;
    }
}
