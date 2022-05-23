using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerControl : MonoBehaviour
{
    public ToGameOver gameOver;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI WaveText;
    public float totalTime;
    int seconds;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Invoke(nameof(Display), 4.5f);
    }

    void Start2()
    {
        this.gameObject.SetActive(false);
        WaveText.text = "Wave 2";
        Invoke(nameof(Display), 0f);
    }

    void Start3()
    {
        this.gameObject.SetActive(false);
        WaveText.text = "Wave 3";
        Invoke(nameof(Display), 0f);
    }

    void Start4()
    {
        this.gameObject.SetActive(false);
        WaveText.text = "Final Wave";
        Invoke(nameof(Display), 0f);
    }

    void Display()
    {
        this.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        //カウントダウンの処理
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        TimerText.text = seconds.ToString();

        if (totalTime < 0 && count == 3)
        {
            gameOver.GameOver();
        }
        
        if (totalTime < 0 && count == 2)
        {
            totalTime = 120;
            count++;
            Start4();
        }

        if (totalTime < 0 && count == 1)
        {
            totalTime = 30;
            count++;
            Start3();
        }

        if (totalTime < 0 && count == 0)
        {
            totalTime = 30;
            count++;
            Start2();
        }
    }
}
