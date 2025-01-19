// クリア判定スクリプト(根来)
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public string targetTag = "Target";
    public Text clearText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(clearText != null)
        {
            clearText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        Debug.Log("残りのターゲット数: " + targets.Length);
        if(targets.Length == 0)
        {
            ShowClearText();
        }
    }
    void ShowClearText()
    {
        if(clearText != null)
        {
            clearText.enabled = true;
            clearText.text = "クリア!";
        }

    }
}
