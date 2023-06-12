using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Skills : MonoBehaviour
{
    
Vector3 ray;//�� ����ĳ��Ʈ�� ����.
int ray_num;
 public int Speed;
 int j=0; 
    public GameObject[] Mob_List;//���� ��ųʸ��� ����
    public List<GameObject> Target_List_Origin = new List<GameObject>();//������ ���� ��������Ʈ
    public List<GameObject> Target_List_Sort= new List<GameObject>();//������ ���� ���� �� ����Ʈ
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Skill_Three();
    }

    private void OnTriggerStay2D(Collider2D other) {
        Skiil_One_Two(other);
    }

    void Skiil_One_Two(Collider2D other){
        if(this.gameObject.tag == "Skill_one"){
            if(other.gameObject.tag =="Enemy"){
                    Debug.Log("�浹");
                    other.gameObject.transform.position =Vector2.MoveTowards(other.gameObject.transform.position, 
                    new Vector2(other.gameObject.GetComponent<Unit>().team_target_tower.position.x,other.gameObject.transform.position.y)
                    , this.Speed * Time.deltaTime);
                }
            }
        else if(this.gameObject.tag == "Skill_two"){
            if(other.gameObject.tag =="Enemy"){
                    Debug.Log("�� �浹");
                    if(other.gameObject.GetComponent<Unit>().is_Half == true){
                        other.gameObject.transform.position = new Vector2(-1.7f,-3.7f);
                        Sort(other);
                    }
                    else{
                        other.gameObject.transform.position = new Vector2(1.7f,-3.7f);
                        other.gameObject.GetComponent<Unit>().is_stop = true;//�ε��� ��ü�� �̵�����.
                        Sort(other);
                    }
                    
                }
            }
    }
    void Skill_Three(){
         ray = new Vector3(0.5f, 0, 0);
         Debug.DrawRay(this.gameObject.transform.position, ray * 10f, new Color(0, 1, 0));
                RaycastHit2D rayhit = Physics2D.Raycast(this.gameObject.transform.position, ray, 10f, LayerMask.GetMask("Enemy"));
                if (rayhit.collider != null)
                {
                    Target_List_Origin.Add(rayhit.collider.gameObject);
                }
        //Target_List_Sort = Target_List_Origin.Where(GetComponent<Unit>().Unit_HP / 100 < 0);
         if(this.gameObject.tag == "Skill_Three"){
          
        }
    }
    void Sort(Collider2D other){
        for(int s=0;s<Mob_List.Length;s++){
                       if(Mob_List[s] != other.gameObject){
                            for(int j =0;j<Mob_List.Length;j++){
                                if(other.gameObject != Mob_List[j]){
                                    Mob_List[s] = other.gameObject;
                                }
                                else if(other.gameObject == Mob_List[j]){
                                    Mob_List[j] = null;
                                    Mob_List[s] = other.gameObject;
                                }
                            }
                        }
                    }
    }

    public void Destroy_Skill(){
        for(int i =0;i< Mob_List.Length;i++){
            if(Mob_List[i] != null){
                 Mob_List[i].gameObject.GetComponent<Unit>().is_stop = false;//��ü �̵� �����ϰ���
            }
            else{
                continue;
            }
        }
        Destroy(this.gameObject);
    }
}
