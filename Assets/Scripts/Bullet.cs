using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    //속력
    public float bulletSpeed = 10;

    //폭발효과 공장
    public GameObject exploFactory;
    void Start()
    {
        //만약에 내것이라면
        if(photonView.IsMine)
        {
            //collider를 활성화
            GetComponent<SphereCollider>().enabled = true;
        }
        //그렇지 않다면
        else
        {
            //Rigidbody 삭제
            Destroy(GetComponent<Rigidbody>());
        }
    }

    void Update()
    {
        //앞으로 간다!! P = P0 + vt
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("RpcOnTriggerEnter", RpcTarget.All, transform.position);
    }

    void RpcOnTriggerEnter(Vector3 position)
    {
        //폭발효과 만든다.
        GameObject explo = Instantiate(exploFactory);
        //폭발효과를 나의 위치로 놓는다.
        explo.transform.position = position;
        //2초뒤에 폭발효과 파괴
        Destroy(explo, 2);

        //만약에 내것이라면
        if (photonView.IsMine)
        {
            //나 자신을 파괴한다.
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
