using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
//using UnityEditor.Experimental.GraphView;
using UnityEngine.EventSystems;


//��, CharacterController�� ���

public class CAJ_PlayerMove : MonoBehaviourPun
{
    //�г���
    public Text nickName;
    
    
    // --------�÷��̾� �̵�--------
    //�ӷ�
    public float moveSpeed = 5;
    CharacterController cc; //characterController ���� ����
    //�߷�
    float gravity = -9.81f;
    //�����Ŀ�
    public float jumpPower = 5;
    //y���� �ӷ�
    float yVelocity;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        
        //�г��� ����
        nickName.text = photonView.Owner.NickName;
    }

    void Update()
    {
        //���࿡ �� ���� �ƴ϶�� �Լ��� �����ڴ�.
        if (photonView.IsMine == false) return;
        {
            //Ŀ���� �� ���� ���� �����̰� ����
            if (Cursor.visible == false)
            {
                //Move();
                float h = Input.GetAxisRaw("Horizontal"); //A : -1, D : 1, ������ ������ : 0
                float v = Input.GetAxisRaw("Vertical");

                //2. ���� ��ȣ�� ������ �����.
                Vector3 dir = transform.forward * v + transform.right * h; // new Vector3(h, 0, v);
                //������ ũ�⸦ 1���Ѵ�.
                dir.Normalize();

                //���࿡ �ٴڿ� ����ִٸ� yVelocity�� 0���� ����
                if (cc.isGrounded)
                {
                    yVelocity = 0;
                }

                //���࿡ �����̹�(Jump)�� ������
                if (Input.GetButtonDown("Jump"))
                {
                    //yVelocity�� jumpPower�� ����
                    yVelocity = jumpPower;
                }

                //yVelocity���� �߷����� ���ҽ�Ų��.
                yVelocity += gravity * Time.deltaTime;

                //dir.y�� yVelocity���� ����
                dir.y = yVelocity;

                //3. �� �������� ��������.
                //P = P0 + vt
                cc.Move(dir * moveSpeed * Time.deltaTime);
            }
            //�� ���� �ƴ϶��
            else
            {
                //Lerp �� �̿��ؼ� �̵� �� ȸ��
            }
        }
        
        


    }
}