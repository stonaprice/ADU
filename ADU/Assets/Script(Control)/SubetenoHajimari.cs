using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubetenoHajimari : MonoBehaviour
{
    public StartText starttext;
    public TimerControl timercontrol;


    //　会話終わったあとにWave1を呼び出すメソッド
    private void battleStart(){
        starttext.PlayStart();
        timercontrol.TimerStart();

        //GameObject obj = (GameObject)Resources.Load("Timer");
        //GameObject instance = (GameObject)Instantiate(obj);


        //Time.timeScale = 1;
    }

}
