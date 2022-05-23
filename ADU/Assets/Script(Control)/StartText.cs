using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public GameObject button1;
    public GameObject button2;

    private void Start()
    {
        //�������\���ɂ���
        this.gameObject.SetActive(false);

        //�{�^�����\���ɂ���
        button1.SetActive(false);
        button2.SetActive(false);

        //0.5�b��Ɏ��s
        Invoke(nameof(DisplayOn), 0.5f);

        //2.5�b��Ɏ��s
        Invoke(nameof(ChangeText), 2.5f);

        //4.5�b��Ɏ��s
        Invoke(nameof(DisplayOff), 4.5f);
    }

    void DisplayOn()
    {
        //�I�u�W�F�N�g��\������
        this.gameObject.SetActive(true);

        //�X�N���v�g�̖������i������ł��Ȃ��悤�ɂ��邽�߁j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = false;
    }

    void ChangeText()
    {
        //������ύX
        Text.text = "START!!";
        //�����F��ύX
        Text.color = Color.red;
    }

    void DisplayOff()
    {
        //������\������
        this.gameObject.SetActive(false);

        //�{�^����\���ɂ���
        button1.SetActive(true);
        button2.SetActive(true);

        //�X�N���v�g�̗L�����i������ĊJ�j
        GameObject playerObj = GameObject.Find("Player");
        PlayerMove playerMove = playerObj.GetComponent<PlayerMove>();
        playerMove.enabled = true;
    }
}