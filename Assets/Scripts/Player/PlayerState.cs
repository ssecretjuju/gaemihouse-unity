using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerState : MonoBehaviourPun
{
    //�÷��̾� ���� ����
    public enum State
    {
        IDLE,
        MOVE
    }

    //���� ����
    public State currState;
    //Animator
    public Animator anim;

    //���� ����
    public void ChangeState(State s)
    {
        photonView.RPC("RpcChangeState", RpcTarget.All, s);
    }

    [PunRPC]
    public void RpcChangeState(State s)
    {
        //���� ���°� s�� ���ٸ� �Լ��� ������.
        if (currState == s) return;

        //���� ���¸� s�� ����
        currState = s;

        //s�� ���� animation �÷���
        switch (currState)
        {
            case State.IDLE:
                anim.SetTrigger("Idle");
                break;
            case State.MOVE:
                anim.SetTrigger("Move");
                print("move");
                break;
        }
    }

    [PunRPC]
    public void RpcSetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
