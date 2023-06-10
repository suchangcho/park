using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager
{
    // Delegate 
    public Action key_action = null;

   public void OnUpdate()//
   {
        // �Է� ���� Ű�� �ƹ��͵� ���ٸ� ����
        if (Input.anyKey == false) return;

        // � Ű�� ���Դٸ�, keyaction���� �̺�Ʈ�� �߻������� ����. 
        if (key_action != null)
        {
            key_action.Invoke();

        }
   }
}
