using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
     public Animator anim;
    Vector3 ray;//�� ����ĳ��Ʈ�� ����.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(this.gameObject.tag == "Skill_one"){
            if(other.gameObject.tag =="Enemy"){
                Debug.Log("�浹");
                other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right *1.5f;
                }
            else if(other.gameObject.tag == "Enemy_Tower"){
                    Destroy(this.gameObject);
                }
            }
        }
  
}
