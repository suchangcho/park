using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//커스텀 클래스는 인스펙터창에서 수정하기위해서는 이 명령어가 필요하다
public class Skill_Manager{
    public int Skill_num;//스킬의 넘버.(구별용)
    public string Skill_name;//스킬이름
    public GameObject Skill;//스킬 객체
}
