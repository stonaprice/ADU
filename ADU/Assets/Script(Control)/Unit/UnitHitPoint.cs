using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHitPoint : MonoBehaviour
{
    // ���j�b�g�̍ő�HP
	[SerializeField]
	private int maxHp = 3;
    // ���j�b�g�̌���HP
	// [SerializeField]
	private int currentHp = 3;
    // HP�\���pUI
    [SerializeField]
    private GameObject HPUI;
    // HP�\���p�X���C�_�[
    private Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
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

        currentHp -= value;

        // HP�\���pUI�̃A�b�v�f�[�g
        UpdateHPValue();

        if(currentHp <= 0)
        {
            Dead();
        }
    }

  // ���S���̏���
    void Dead()
    {
        Destroy(gameObject);
    }

    //����ɐG�ꂽ��_���[�W
    protected void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.CompareTag("PlayerUnit")){
            if (collision.gameObject.CompareTag("EnemyWeapon")){
                int value = 1;
                Damage(value);
            }
        }
        else if(this.gameObject.CompareTag("EnemyUnit")){
            if (collision.gameObject.CompareTag("PlayerWeapon")){
                int value = 1;
                Damage(value);
            }
        }
    }

	public void SetCurrentHp(int hp){
		this.currentHp = currentHp;
	}

	public int GetCurrentHp(){
		return currentHp;
	}

    public int GetMaxHp() {
        return maxHp;
    }

    public void UpdateHPValue(){
        hpSlider.value = (float)GetCurrentHp() / (float)GetMaxHp();
    }
}
