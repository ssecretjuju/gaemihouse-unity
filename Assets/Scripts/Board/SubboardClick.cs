using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubboardClick : MonoBehaviour
{

    GameObject subboard;
    GameObject ConfirmWindow;

    void Start()
    {
        ConfirmWindow = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;
       
    }

    public void OnClickSubboard()
    {
        //���� ������ ����,�г���,��¥,������ ǥ�õǾ��ִ� â�� ���.
        ConfirmWindow.SetActive(true);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
