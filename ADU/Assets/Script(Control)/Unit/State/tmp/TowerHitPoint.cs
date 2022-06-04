using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHitPoint : MonoBehaviour
{
    // ����HP
	[SerializeField]
	private int maxHp;
    // ����HP
    // [SerializeField]
    private int hp;
    // HP�\���pUI
    [SerializeField]
    private GameObject HPUI;
    // HP�\���p�X���C�_�[
    private Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ��_���[�W����
    public void Damage(int value)
    {
        if(value <= 0)
        {
            return;
        }

        hp -= value;

        Debug.Log(hp);

        // HP�\���pUI�̃A�b�v�f�[�g
        UpdateHPValue();

        // if(Hp <= 0)
        // {
        //     Dead();
        // }
    }

    //����ɐG�ꂽ��_���[�W
    protected void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.CompareTag("PlayerTower")){
            if (collision.gameObject.CompareTag("EnemyWeapon")){
                int value = 1;
                Damage(value);
            }
        }
        else if(this.gameObject.CompareTag("EnemyTower")){
            if (collision.gameObject.CompareTag("PlayerWeapon")){
                int value = 1;
                Damage(value);
            }
        }

    }

    public void SetHp(int hp) {
        this.hp = hp;

        // HP�\���pUI�̃A�b�v�f�[�g
        UpdateHPValue();

        // if (hp <= 0) {
        //     // HP�\���pUI���\���ɂ���
        //     HideStatusUI();
        // }
    }

    public int GetHp() {
        return hp;
    }

    public int GetMaxHp() {
        return maxHp;
    }

    public void UpdateHPValue() {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }
}
