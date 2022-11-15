using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerRot : MonoBehaviourPun
{
    // ȸ�� �ӷ� 
    public float rotSpeed = 200;

    //CamPos�� Transform
    public Transform CameraPivot;

    //ȸ���� ���� ����
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        //���࿡ �����̶��
        if (photonView.IsMine == true)
        {
            //camPos�� Ȱ��ȭ �Ѵ�.
            CameraPivot.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���࿡ ������ �ƴ϶�� �Լ��� ������.
        if (photonView.IsMine == false) return;
        if (Cursor.visible == true) return;

        //1. ���콺�� �������� �޴´�.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. ���콺�� �����Ӱ����� ȸ������ ������Ų��.
        rotX += mx * rotSpeed * Time.deltaTime;
        rotY += my * rotSpeed * Time.deltaTime;

        //3. �÷����� ȸ�� y���� �����Ѵ�.
        transform.localEulerAngles = new Vector3(0, rotX, 0);
        //4. CamPos�� ȸ�� x���� �����Ѵ�.
        CameraPivot.localEulerAngles = new Vector3(-rotY, 0, 0);

    }
}
