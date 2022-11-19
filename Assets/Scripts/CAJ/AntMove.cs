using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


//��, CharacterController�� ���

public class AntMove : MonoBehaviourPun, IPunObservable
{
    //�ӷ�
    public float moveSpeed = 30;
    //characterController ���� ����
    CharacterController cc;
    //y���� �ӷ�
    float yVelocity;

    //�߷�
    float gravity = -9.81f;
    //�����Ŀ�
    public float jumpPower = 5;

    //�г��� UI
    //public Text nickName;

    //���� ��ġ
    Vector3 receivePos;
    //ȸ���Ǿ� �ϴ� ��
    Quaternion receiveRot;
    //���� �ӷ�
    public float lerpSpeed = 100;

    //PlayerState ������Ʈ
    PlayerState playerState;

    public Animator anim;

    void Start()
    {
        //characterController �� ����
        cc = GetComponent<CharacterController>();
        //����ü���� �ִ�ü������ ����
        //currHp = maxHp;
        //�г��� ����
        //nickName.text = photonView.Owner.NickName;
        //PlayerState ������Ʈ ��������
        playerState = GetComponent<PlayerState>();
        //GameManager���� ���� PhotonView�� ����
        //GameManager.instance.AddPlayer(photonView);
    }

    void Update()
    {
        //���࿡ �����̶��
        if (photonView.IsMine)
        {
            {
                // WSAD�� ������ ��,��,��,��� �̵�
                //1. WSAD�� ��ȣ�� ����.
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

                if (dir.magnitude > 0)
                {
                    anim.SetTrigger("Move");

                    //���ÿ��� ����� �Ÿ� �ּ�ó���ϰ�, ���� �� ���
                    //playerState.ChangeState(PlayerState.State.MOVE);
                }
                else
                {
                    anim.SetTrigger("Idle");
                    //playerState.ChangeState(PlayerState.State.IDLE);
                }

                //yVelocity���� �߷����� ���ҽ�Ų��.
                yVelocity += gravity * Time.deltaTime;

                //dir.y�� yVelocity���� ����
                dir.y = yVelocity;

                //3. �� �������� ��������.
                //P = P0 + vt
                cc.Move(dir * moveSpeed * Time.deltaTime);

                //���࿡ �����δٸ�
                if (h != 0 || v != 0)
                {
                    //print("h 0 �ƴ�");
                    //���¸� Move��
                    playerState.ChangeState(PlayerState.State.MOVE);
                    //print(11111111111);
                }
                //�׷��� �ʴٸ�
                else
                {
                    //���¸� Idle��
                    playerState.ChangeState(PlayerState.State.IDLE);
                }
            }
        }
        //������ �ƴ϶��
        else
        {
            ////Lerp�� �̿��ؼ� ������, ����������� �̵� �� ȸ��
            //transform.position = Vector3.Lerp(transform.position, receivePos, lerpSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, receiveRot, lerpSpeed * Time.deltaTime);
            return;
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //������ ������
        if (stream.IsWriting) // isMine == true
        {
            //position, rotation
            stream.SendNext(transform.rotation);
            stream.SendNext(transform.position);
        }
        //������ �ޱ�
        else if (stream.IsReading) // ismMine == false
        {
            receiveRot = (Quaternion)stream.ReceiveNext();
            receivePos = (Vector3)stream.ReceiveNext();
        }
    }
}
