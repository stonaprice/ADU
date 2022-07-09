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
    public GameObject[] shingakuImages = new GameObject[3];
    public GameObject[] shingakuButton = new GameObject[3];

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
                    SaveUnit _saveUnit = saveUnit.GetComponent<SaveUnit>();
                    
                    images[i].GetComponent<SummonUnit>().Unit1 = _saveUnit.selectedUnit[i];
                    images[i].GetComponent<Image>().sprite = _saveUnit.selectedSprite[i];
                    
                    shingakuImages[i].GetComponent<Image>().sprite = _saveUnit.selectedSprite[i];
                    
                    shingakuButton[i].GetComponent<ShingakuButton>().Unit = _saveUnit.selectedUnit[i];
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
