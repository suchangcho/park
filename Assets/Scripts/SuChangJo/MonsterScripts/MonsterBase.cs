using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")] //�����̸��� �����̰� ��ũ��Ʈ ����� ȭ�鿡�� ��������
public class MonsterBase : ScriptableObject
{
    public string name;   //�̸� ���� 
    //[SerializeField]:�ܺ� ��ũ��Ʈ���� ������ ���ϰ� �ҷ��� ���
    
    [TextArea]
    public string description; //ĳ���� ����

    public Sprite monster; //���� ����


    public int maxHp;//�ִ� ü��
    public int attack;//���ݷ�
    public int attackSpeed; //���ݼӵ�
    public int speed; //���ǵ�

    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int AttackSpeed
    {
        get { return attackSpeed; }
    }
    public int Speed
    {
        get { return speed; }
    }




}
