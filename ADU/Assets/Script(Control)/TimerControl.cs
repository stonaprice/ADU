using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerControl : MonoBehaviour
{
    public ToGameOver gameOver;
    public SummonUnit summonUnit;
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

        for (int i = 0; i <= 8; i++)
        {
            summonUnit.UnitSummon();
        }

        Invoke(nameof(Display), 0f);
    }

    void Start3()
    {
        this.gameObject.SetActive(false);
        WaveText.text = "Wave 3";

        for (int i = 0; i <= 11; i++)
        {
            summonUnit.UnitSummon();
        }

        Invoke(nameof(Display), 0f);
    }

    void Start4()
    {
        this.gameObject.SetActive(false);
        WaveText.text = "Final Wave";

        for (int i = 0; i <= 14; i++)
        {
            summonUnit.UnitSummon();
        }

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

        //Gameoverへ移行
        if (totalTime < 0 && count == 3)
        {
            gameOver.GameOver();
        }

        //FinalWave移行の条件分岐
        if (totalTime < 0 && count == 2)
        {
            totalTime = 120;
            count++;
            Start4();
        }

        //Wave3移行の条件分岐
        if (totalTime < 0 && count == 1)
        {
            totalTime = 30;
            count++;
            Start3();
        }

        //Wave2移行の条件分岐
        if (totalTime < 0 && count == 0)
        {
            totalTime = 30;
            count++;
            Start2();
        }
    }
}
