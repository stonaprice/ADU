using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TimerControl : MonoBehaviour
{
    public ToGameOver gameOver;
    public SummonUnit summonUnit;
    public CostControl costControl;
    public Text TimerText;
    public Text WaveText;
    public TextMeshProUGUI WaveTextAnime;
    public Text CostText;
    public float totalTime;
    int seconds;
    int count = 0;
    float maxEnemyCost;

    // Start is called before the first frame update
    public void TimerStart()
    {
        //Time.timeScale = 0;
        this.gameObject.SetActive(false);
        Invoke(nameof(Display), 4.5f);
    }

    void Initiative(float playerCost, float enemyCost, string text)
    {
        this.gameObject.SetActive(false);
        
        costControl.SetPlayerCost(playerCost);
        costControl.CostAnimation();
        costControl.ActivButton();
        
        WaveText.text = text;
        WaveAnimeReset();
        WaveTextAnime.text = text;
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);
        
        // summonEnemyUnit
        costControl.SetEnemyCost(enemyCost);
        maxEnemyCost = costControl.GetEnemyCost();
        for (int i = 0; i < maxEnemyCost; i++)
        {
            summonUnit.UnitSummon(true);
        }
        
        Invoke(nameof(Display), 0f);
    }

    void Start2()
    {
        Initiative(10, 10, "Wave 2");
    }

    void Start3()
    {
        Initiative(20, 20, "Wave 3");
    }

    void Start4()
    {
        Initiative(40, 40, "FInal Wave");
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
        CostText.text = string.Format("{0} / {1}", costControl.GetPlayerCost(), costControl.PlayerMaxCost);

        //Gameover?��ֈڍs
        if (totalTime < 0 && count == 3)
        {
            Invoke("End", 1.0f);
            count++;
        }

        //FinalWave?��ڍs?��̏�?��?��?��?��?��?��
        if (totalTime < 0 && count == 2)
        {
            totalTime = 100;
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
    
    void End()
    {
            gameOver.ChangeScene();
    }
}
