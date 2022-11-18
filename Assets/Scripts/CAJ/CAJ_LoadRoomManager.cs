using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

//�� ������ �޾ƿ´�
//�� ����(�̸�, ���ͷ�)�� ���� ���� �����
//������� ���� Ŭ���� ��, JoinOrCreateRoom()���� ���� Ŭ���ؼ� �����ϰ� ������ش� 
public class CAJ_LoadRoomManager : MonoBehaviour
{
    //private string FilePath = "D:\[Project]5. GaemiHouse\gaemihouse-unity\Assets\Data";
    public void OnClickGetPostAll()
    {
        //������ �� ��� ��ȸ ��û (shareholder-room, GET)

        //HttpRequester �� ����
        HttpRequester requester = new HttpRequester();

        //shareholder-room , GET
        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.GET;

        requester.onComplete = OnCompleteGetPostAll;
        //requester.onComplete(UnityWebRequest.downloadHandler)
        //������ �޾Ƽ� ���

        //HttpManager ���� ��û
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPostAll(DownloadHandler handler)
    {
        //PostData ���� Json ���¸� Ǯ�������
        PostData postData = JsonUtility.FromJson<PostData>(handler.text);

        //Ÿ��Ʋ UI�� ���
        //���� UI�� ���
        print("��ȸ�Ϸ�");
    }


    public void OnClickSignIn()
    {

    }

    public void OnCompleteSignIn(DownloadHandler handler)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        OnClickGetPostAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
