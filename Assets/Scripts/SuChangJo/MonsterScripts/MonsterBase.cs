using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")] //�����̸��� �����̰� ��ũ��Ʈ ����� ȭ�鿡�� ��������
public class MonsterBase : ScriptableObject
{
    [SerializeField] string name;          //�̸� ���� 
    //[SerializeField]:�ܺ� ��ũ��Ʈ���� ������ ���ϰ� �ҷ��� ���

    [TextArea]
    [SerializeField] string description; //ĳ���� ����

    [SerializeField] Sprite monster; //���� ����

    public int level = 1;
    public int maxHp; //�ִ� ü��
    public int CurHP; //���� ü��
    public int attack; //���ݷ�
    public int attackSpeed; //���ݼӵ�
    public int speed; //���ǵ�

}
