using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;


public class TimerController : MonoBehaviour
{
    public Image progressRing;
    public float waitTime = 3.0f;
    public float finishDelay = 1.0f;

    private bool progress;

    public Action OnFinish;

    private void Start()
    {
        CancelTimer();
    }

    async Task Update()
    {
        if (progress)
        {
            progressRing.fillAmount += 1.0f / waitTime * Time.deltaTime;
            if (1 <= progressRing.fillAmount)
            {
                progress = false;
                await Task.Delay((int)(finishDelay * 1000));
                progressRing.fillAmount = 0;
                OnFinish?.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        progress = true;
    }

    public void CancelTimer()
    {
        progressRing.fillAmount = 0;
        progress = false;
    }
}
