using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdownBar : MonoBehaviour
{
    [SerializeField] private Image timeCountdownBar;
    private float timer;
    private float stopCountTimer;
    private float timeDuration;
    public bool isTimeOver;
    public bool isTimeStop;


    public void Start()
    {
        timeDuration = 5f;
        timer = timeDuration;
        isTimeOver = false;
        isTimeStop = false;
    }

    void Update()
    {
        if (timer >= 0)
        {
            if (!isTimeStop)
                timer -= Time.deltaTime;
            else
            {
                if (stopCountTimer >= 0)
                    stopCountTimer -= Time.deltaTime;
                else
                    isTimeStop = false;

            }

            timeCountdownBar.fillAmount = timer / timeDuration;
        }
        else
        {
            gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            isTimeOver = true;
        }
    }

    public void StopCounting(float sec)
    {
        isTimeStop = true;
        stopCountTimer = sec;
    }
}
