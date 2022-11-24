using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �ٸ� ĳ���͸� Ŭ���ϸ� �ش� ĳ������ ������ �߰� �ϰ�ʹ�.

public class ClickProfile : MonoBehaviour
{
    Text otherNickName;
    RaycastHit hit;
    public GameObject profileInfoImage;
    // Start is called before the first frame update
    void Start()
    {
        otherNickName = GameObject.Find("NicknameCanvas").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        otherNickName.text = null;
            
        Debug.Log("room");
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("???");
            if (Physics.Raycast(ray, out hit))
            {
            Debug.Log(hit.transform.gameObject);
               
                if (hit.transform.gameObject.tag == "Player")
                {
                    otherNickName.text = (hit.collider.name);
                    print(otherNickName);
                    // �������̹��� ����
                    GameObject profileItem = Instantiate(profileInfoImage);
                    print("�ٸ����");
                }
            }
        }
    }
}

