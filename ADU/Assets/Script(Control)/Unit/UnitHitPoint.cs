using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHitPoint : MonoBehaviour
{
    // ユニットの最大HP
	[SerializeField]
	private int maxHp = 3;
    // ユニットの現在HP
	// [SerializeField]
	private int currentHp = 3;
    // HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    // HP表示用スライダー
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

    // 被ダメージ処理
    public void Damage(int value)
    {
        if(value <= 0)
        {
            return;
        }

        currentHp -= value;

        // HP表示用UIのアップデート
        UpdateHPValue();

        if(currentHp <= 0)
        {
            Dead();
        }
    }

  // 死亡時の処理
    void Dead()
    {
        Destroy(gameObject);
    }

    //武器に触れたらダメージ
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
