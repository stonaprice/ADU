using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;


public class SkipManager : MonoBehaviour
{
    public GameObject skipButton;
    public Flowchart flowchart;
    public string endBlock;


    public void pushSkipButton()
    {
        Debug.Log("pushed!");
        // �X�L�b�v�{�^��������
        skipButton.SetActive(false);
        // ���݂̃u���b�N���~����
        flowchart.StopAllBlocks();
        // ��b�I��
        flowchart.ExecuteBlock(endBlock);
    }
}
