using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubetenoHajimari : MonoBehaviour
{
    private StartText starttext;
    private TimerControl timercontrol;


    //　会話終わったあとにWave1を呼び出すメソッド
    private void battleStart(){
        starttext.Start();
        timercontrol.Start();
    }

}
