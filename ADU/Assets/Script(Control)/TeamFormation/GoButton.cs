using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class GoButton : MonoBehaviour
{
    private bool _firstPush = false;

    private bool _empty = false;
    private GameObject saveUnit;
    private SaveUnit _saveUnit;

    private void Start()
    {
        saveUnit = GameObject.Find("SaveUnit");
        _saveUnit = saveUnit.GetComponent<SaveUnit>();
    }

    public void GoToFight()
    {
        Debug.Log("Press Start!");
        if (!_firstPush)
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsNull(_saveUnit.selectedUnit[i]))
                {
                    _empty = true;
                    
                    break;
                }else if (IsNull(_saveUnit.selectedSprite[i]))
                {
                    _empty = true;
                    
                    break;
                }
                // if (ReferenceEquals(_saveUnit.selectedUnit[i], null))
                // {
                //     _empty = true;
                //     
                //     break;
                // }
                // else if (ReferenceEquals(_saveUnit.selectedSprite[i], null))
                // {
                //     _empty = true;
                //
                //     break;
                // }
                
                // Debug.Log(_saveUnit.selectedUnit[i]);
                // Debug.Log(_empty);
            }
            
            if (!_empty)
            {
                Debug.Log("Go Next Scene!");
                //ここに次のシーンへいく命令を書く
                SceneManager.LoadScene("Fight");//Fightシーンをロードする
            
                _firstPush = true;
            }
        }

        _empty = false;
    }
    
    static bool IsNull<T>(T obj) where T : class {
        var unityObj = obj as UnityEngine.Object;
        if (!object.ReferenceEquals(unityObj, null)) {
            return unityObj == null;
        } else {
            return obj == null;
        }
    }
}
