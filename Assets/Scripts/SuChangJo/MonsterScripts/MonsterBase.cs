using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")] //�����̸��� �����̰� ��ũ��Ʈ ����� ȭ�鿡�� ��������
public class MonsterBase : ScriptableObject
{
    [SerializeField] string name;   //�̸� ���� 
    //[SerializeField]:�ܺ� ��ũ��Ʈ���� ������ ���ϰ� �ҷ��� ���
    
    [TextArea]
    [SerializeField] string description; //ĳ���� ����

    [SerializeField] Sprite monster; //���� ����


    public int maxHp { get { return maxHp; }} //�ִ� ü��
    public int curHP { get { return curHP; }}//���� ü��
    public int attack { get { return attack; } }//���ݷ�
    public int attackSpeed { get { return attackSpeed; } } //���ݼӵ�
    public int speed { get { return speed; } } //���ǵ�


}
