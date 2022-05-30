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

    

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Invoke(nameof(Display), 4.5f);
    }

    void Start2()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetCost(10);
        costControl.ActivButton();
        WaveText.text = "Wave 2";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // for (int i = 0; i <= 8; i++)
        // {
        //     summonUnit.UnitSummon();
        // }

        Invoke(nameof(Display), 0f);
    }

    void Start3()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetCost(10);
        costControl.ActivButton();
        WaveText.text = "Wave 3";
        WaveAnimeReset();
        WaveTextAnime.text = "Wave 3";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // for (int i = 0; i <= 11; i++)
        // {
        //     summonUnit.UnitSummon();
        // }

        Invoke(nameof(Display), 0f);
    }

    void Start4()
    {
        this.gameObject.SetActive(false);
        // costControl.cost = 10;
        costControl.SetCost(10);
        costControl.ActivButton();
        WaveText.text = "Final Wave";
        WaveAnimeReset();
        WaveTextAnime.text = "Final Wave";
        Invoke(nameof(WaveAnime), 0f);
        Invoke(nameof(WaveAnime2), 2f);

        // for (int i = 0; i <= 14; i++)
        // {
        //     summonUnit.UnitSummon();
        // }

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

        //WaveTextAnime繧貞承蛛ｴ縺ｫ謌ｻ縺?
        Vector3 localPos = myTransform.localPosition;
        localPos.x = 3000f;
        myTransform.localPosition = localPos;
    }

    // Update is called once per frame
    void Update()
    {
        //?ｿｽJ?ｿｽE?ｿｽ?ｿｽ?ｿｽg?ｿｽ_?ｿｽE?ｿｽ?ｿｽ?ｿｽﾌ擾ｿｽ?ｿｽ?ｿｽ
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        TimerText.text = seconds.ToString();
        CostText.text = string.Format("{0} / 10", costControl.GetCost());

        //Gameover?ｿｽﾖ移行
        if (totalTime < 0 && count == 3)
        {
            gameOver.GameOver();
        }

        //FinalWave?ｿｽﾚ行?ｿｽﾌ擾ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        if (totalTime < 0 && count == 2)
        {
            totalTime = 120;
            count++;
            Start4();
        }

        //Wave3?ｿｽﾚ行?ｿｽﾌ擾ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        if (totalTime < 0 && count == 1)
        {
            totalTime = 30;
            count++;
            Start3();
        }

        //Wave2?ｿｽﾚ行?ｿｽﾌ擾ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ?ｿｽ
        if (totalTime < 0 && count == 0)
        {
            totalTime = 30;
            count++;
            Start2();
        }
    }
}
