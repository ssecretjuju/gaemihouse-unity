using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;

    float width;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// ���ӻ��°� Playing �� �ƴϸ�??
        //if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        //{
        //    // -> ó������ ���ϰ� ����.
        //    return;
        //}

        // ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. ������ �ʿ�
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        dir.Normalize();
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        Vector3 myPos = transform.position;
        myPos += dir * speed * Time.deltaTime;
        // �������� -4.3, ���������� +4.3 �Ѿ�� �ʵ��� �ϰ�ʹ�.
        //myPos.x = Mathf.Clamp(myPos.x, -width, width);


        transform.position = myPos;
    }
}
