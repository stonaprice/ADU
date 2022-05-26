using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TimerControl : MonoBehaviour
{
    public ToGameOver gameOver;
    public SummonUnit summonUnit;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI WaveTextAnime;
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
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

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
        //WaveTextAnime.text = "Wave 3";
        //Invoke(nameof(WaveAnime), 0f);
        //Invoke(nameof(WaveAnime2), 2f);

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
        //WaveTextAnime.text = "Final Wave";
        //Invoke(nameof(WaveAnime), 0f);
        //Invoke(nameof(WaveAnime2), 2f);

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

    void WaveAnime()
    {
        WaveTextAnime.transform.DOLocalMove(new Vector3(0, 0, 0), 1f);
    }

    void WaveAnime2()
    {
        WaveTextAnime.transform.DOLocalMove(new Vector3(-1000, 0, 0), 1f);
    }


    // Update is called once per frame
    void Update()
    {
        //�J�E���g�_�E���̏���
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        TimerText.text = seconds.ToString();

        //Gameover�ֈڍs
        if (totalTime < 0 && count == 3)
        {
            gameOver.GameOver();
        }

        //FinalWave�ڍs�̏�������
        if (totalTime < 0 && count == 2)
        {
            totalTime = 120;
            count++;
            Start4();
        }

        //Wave3�ڍs�̏�������
        if (totalTime < 0 && count == 1)
        {
            totalTime = 30;
            count++;
            Start3();
        }

        //Wave2�ڍs�̏�������
        if (totalTime < 0 && count == 0)
        {
            totalTime = 30;
            count++;
            Start2();
        }
    }
}
