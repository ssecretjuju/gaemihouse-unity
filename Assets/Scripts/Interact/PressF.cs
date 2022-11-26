using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressF : MonoBehaviour
{
    //�÷��̾ Ư�� �繰�� �ٰ������� FŰ�� ���� ���� ������ ���.

    bool onPlayer = false;
    public GameObject interObject;
    public GameObject popUpImage;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(onPlayer == true)
        {
            popUpImage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                interObject.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //���� �浹�� ���� �÷��̾���
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            onPlayer = false;
        }
    }
}

