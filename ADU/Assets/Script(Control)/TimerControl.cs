using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TimerControl : MonoBehaviour
{
    public ToGameOver gameOver;
    public SummonUnit summonUnit;
    public CostControl costControl;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI WaveTextAnime;
    public TextMeshProUGUI CostText;
    public float totalTime;
    int seconds;
    int count = 0;
    int maxEnemyCost;


    // Start is called before the first frame update
    public void TimerStart()
    {
        //Time.timeScale = 0;
        this.gameObject.SetActive(false);
        Invoke(nameof(Display), 4.5f);
    }

    void Start2()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetPlayerCost(10);
        costControl.ActivButton();
        WaveText.text = "Wave 2";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        maxEnemyCost = costControl.GetEnemyCost();
        for (int i = 0; i < maxEnemyCost; i++)
        {
            summonUnit.UnitSummon(true);
        }

        Invoke(nameof(Display), 0f);
    }

    void Start3()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetPlayerCost(10);
        costControl.ActivButton();
        WaveText.text = "Wave 3";
        WaveAnimeReset();
        WaveTextAnime.text = "Wave 3";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        maxEnemyCost = costControl.GetEnemyCost();
        for (int i = 0; i < maxEnemyCost; i++)
        {
            summonUnit.UnitSummon(true);
        }

        Invoke(nameof(Display), 0f);
    }

    void Start4()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetPlayerCost(10);
        costControl.ActivButton();
        WaveText.text = "Final Wave";
        WaveAnimeReset();
        WaveTextAnime.text = "Final Wave";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // summonEnemyUnit
        costControl.SetEnemyCost(10);
        maxEnemyCost = costControl.GetEnemyCost();
        for (int i = 0; i < maxEnemyCost; i++)
        {
            summonUnit.UnitSummon(true);
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
        WaveTextAnime.transform.DOLocalMove(new Vector3(-1500, 0, 0), 1f);
    }

    void WaveAnimeReset()
    {
        Transform myTransform = WaveTextAnime.transform;

        //WaveTextAnimeを右側に戻�?
        Vector3 localPos = myTransform.localPosition;
        localPos.x = 3000f;
        myTransform.localPosition = localPos;
    }

    // Update is called once per frame
    void Update()
    {
        //?��J?��E?��?��?��g?��_?��E?��?��?��̏�?��?��
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        TimerText.text = seconds.ToString();
        CostText.text = string.Format("{0} / 10", costControl.GetPlayerCost());

        //Gameover?��ֈڍs
        if (totalTime < 0 && count == 3)
        {
            gameOver.GameOver();
        }

        //FinalWave?��ڍs?��̏�?��?��?��?��?��?��
        if (totalTime < 0 && count == 2)
        {
            totalTime = 120;
            count++;
            Start4();
        }

        //Wave3?��ڍs?��̏�?��?��?��?��?��?��
        if (totalTime < 0 && count == 1)
        {
            totalTime = 30;
            count++;
            Start3();
        }

        //Wave2?��ڍs?��̏�?��?��?��?��?��?��
        if (totalTime < 0 && count == 0)
        {
            totalTime = 30;
            count++;
            Start2();
        }
    }
}
