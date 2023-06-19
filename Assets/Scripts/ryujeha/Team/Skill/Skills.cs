using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Skills : MonoBehaviour
{
 public int Speed;
    [SerializeField] List<int> Target_List_Origin = new List<int>();//������ ���� ��������Ʈ
    [SerializeField] List<int> Target_List_Sort= new List<int>();//������ ���� ���� �� ����Ʈ
    Skill skil;
    // Start is called before the first frame update
    void Start()
    {
      skil = FindObjectOfType<Skill>();
    }

    // Update is called once per frame
    void Update()
    {
        Skill_Three();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(this.gameObject.tag == "Skill_two"){
            if(other.gameObject.tag == "Enemy"){
                other.gameObject.GetComponent<Unit>().is_stop = false;//��ü �̵� �����ϰ��� 
            }
           
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        Skiil_One_Two(other);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(this.gameObject.tag =="Skill_Three"){
            if(other.gameObject.tag == "Enemy"){
                other.GetComponent<Unit>().Unit_HP =0;
                Destroy(this.gameObject);
            }
            
        }
        
    }
    void Skiil_One_Two(Collider2D other){
        if(this.gameObject.tag == "Skill_one"){
            if(other.gameObject.tag =="Enemy"){
                    Debug.Log("�浹");
                    other.gameObject.transform.position =Vector2.MoveTowards(other.gameObject.transform.position, 
                    new Vector2(other.gameObject.GetComponent<Unit>().team_target_tower.position.x,other.gameObject.
                    transform.position.y), this.Speed * Time.deltaTime);
                }
            }
        else if(this.gameObject.tag == "Skill_two"){
            if(other.gameObject.tag =="Enemy"){
                    Debug.Log("�� �浹");
                    if(other.gameObject.GetComponent<Unit>().is_Half == true){
                        other.gameObject.transform.position = new Vector2(-2.3f,other.GetComponent<Unit>().Unit_Ypotion);
                         other.gameObject.GetComponent<Unit>().is_stop = false;
                    }
                    else{
                        other.gameObject.transform.position = new Vector2(1.7f,other.GetComponent<Unit>().Unit_Ypotion);
                        other.gameObject.GetComponent<Unit>().is_stop = true;//�ε��� ��ü�� �̵�����.
                    }
                    
                }
            }
    }
    public void mob_list_add(List<GameObject> Mob_List){
    }
    void Skill_Three(){
        if(this.gameObject.tag == "Skill_Three"){
            try
            {
                    for(int i =0; i <skil.Mob_List.Count;i++)
                    {
                        Target_List_Origin.Add(skil.Mob_List[i].GetComponent<Unit>().Unit_HP);
                    }

                Target_List_Sort = Target_List_Sort.Distinct().ToList();
                Target_List_Sort = Target_List_Origin.OrderBy(x => x).ToList();
                 
                for(int a =0; a<skil.Mob_List.Count;a++){
                    if(Target_List_Sort[0] == skil.Mob_List[a].GetComponent<Unit>().Unit_HP){
                        this.gameObject.transform.position=Vector2.MoveTowards(this.gameObject.transform.position,
                        new Vector2(skil.Mob_List[a].gameObject.transform.position.x,skil.Mob_List[a].gameObject.transform.position.y),this.Speed * Time.deltaTime);
                    }
                }
            }
            catch (System.Exception)
            {
                Destroy(this.gameObject);
            }

        }
    }

    public void Destroy_Skill(){
        Destroy(this.gameObject);
    }
}
