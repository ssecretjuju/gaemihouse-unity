using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������ �ڽ��� ���� ���� 0�̸� �ʿ� �� ������
// ������ �ڽ��� ���� ���� 1�̸� �� ������ �ʴ´�
// ���Ƿ� 1�� �ٲ�� ��ư �ֱ�!!!!
public class KospiWeatherManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KospiInfoManager.Instance.kospiInfo == 0)
        {
            //�񰡳���
        }
        else
        {

        }
    }

    //�� �ٲٴ� ��ư
    public void changeKospi()
    {
        KospiInfoManager.Instance.kospiInfo = 1;
    }
}
