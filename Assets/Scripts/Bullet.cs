using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    //�ӷ�
    public float bulletSpeed = 10;

    //����ȿ�� ����
    public GameObject exploFactory;
    void Start()
    {
        //���࿡ �����̶��
        if(photonView.IsMine)
        {
            //collider�� Ȱ��ȭ
            GetComponent<SphereCollider>().enabled = true;
        }
        //�׷��� �ʴٸ�
        else
        {
            //Rigidbody ����
            Destroy(GetComponent<Rigidbody>());
        }
    }

    void Update()
    {
        //������ ����!! P = P0 + vt
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("RpcOnTriggerEnter", RpcTarget.All, transform.position);
    }

    void RpcOnTriggerEnter(Vector3 position)
    {
        //����ȿ�� �����.
        GameObject explo = Instantiate(exploFactory);
        //����ȿ���� ���� ��ġ�� ���´�.
        explo.transform.position = position;
        //2�ʵڿ� ����ȿ�� �ı�
        Destroy(explo, 2);

        //���࿡ �����̶��
        if (photonView.IsMine)
        {
            //�� �ڽ��� �ı��Ѵ�.
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
