using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubetenoHajimari : MonoBehaviour
{
    public StartText starttext;
    public TimerControl timercontrol;
    public SoundStart soundstart;
    public AudioClip loop;
    AudioSource audioSource;
    
    public GameObject[] images = new GameObject[3];


    //　会話終わったあとにWave1を呼び出すメソッド
    private void battleStart()
    {
        // 編成したユニットへの変更
        GameObject saveUnit = GameObject.Find("SaveUnit");
        if (!ReferenceEquals(saveUnit, null))
        {
            for (int i = 0; i < 3; i++)
            {
                if (!ReferenceEquals(images[i], null))
                {
                    images[i].GetComponent<SummonUnit>().Unit1 = saveUnit.GetComponent<SaveUnit>().selectedUnit[i];
                    images[i].GetComponent<Image>().sprite = saveUnit.GetComponent<SaveUnit>().selectedSprite[i];
                }
            }
        }

        
        starttext.PlayStart();
        soundstart.SoundStop();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = loop;
        soundstart.SoundPlay();
        timercontrol.TimerStart();

        //GameObject obj = (GameObject)Resources.Load("Timer");
        //GameObject instance = (GameObject)Instantiate(obj);


        //Time.timeScale = 1;
    }

}
