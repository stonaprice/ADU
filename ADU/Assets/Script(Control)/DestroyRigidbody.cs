using UnityEngine;
 
public class DestroyRigidbody : MonoBehaviour {
    public GameObject unit1;
 
    void Start() {
        Invoke("DestroyRigid", 3.0f);　// 関数Test1を3秒後に実行
    }
 
    void DestroyRigid() {
        Rigidbody rb = GetComponent<Rigidbody>();
        Destroy(rb);
    }
}
