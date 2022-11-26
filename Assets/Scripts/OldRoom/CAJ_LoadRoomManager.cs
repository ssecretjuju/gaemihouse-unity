using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

//�� ������ �޾ƿ´�
//�� ����(�̸�, ���ͷ�)�� ���� ���� �����

public class CAJ_LoadRoomManager : MonoBehaviour
{
    
    public void OnClickGetPost()
    {
        //������ �� ��� ��ȸ ��û (shareholder-room, GET)

        //HttpRequester �� ����
        HttpRequester requester = new HttpRequester();

        //shareholder-room , GET
        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPost;
        //requester.onComplete(UnityWebRequest.downloadHandler)
        //������ �޾Ƽ� ���

        //HttpManager ���� ��û
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPost(DownloadHandler handler)
    {
        //PostData ���� Json ���¸� Ǯ�������
        RoomData roomData = JsonUtility.FromJson<RoomData>(handler.text);

        //Ÿ��Ʋ UI�� ���
        //���� UI�� ���
        print("��ȸ�Ϸ�");
    }

    public void OnClickGetPostAll()
    {
        //������ �Խù� ��ȸ ��û(/posts/1 , GET)
        //HttRequester�� ����
        HttpRequester requester = new HttpRequester();

        ///posts/1 , GET, �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        //requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPostAll;

        //HttpManager���� ��û
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPostAll(DownloadHandler handler)
    {
        //�迭 �����͸� Ű���� �ִ´�.
        //string s = "{\"data\":" + handler.text + "}";
        string s = "{\"data\":" + handler.text + "}";
        //print(s);


        string a = handler.text;    
        //print("a : " + a);

        //List<PostData>
        RoomDataArray array = JsonUtility.FromJson<RoomDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            
            print(array.data[i].roomTitle + "\n" + array.data[i].roomRegistedNumber + "\n" + array.data[i].roomCode + array.data[i].roomYield + array.data[i].roomLimitedNumber);
            //print(array);
        }
        

        print("��ȸ �Ϸ�");
    }

    // Start is called before the first frame update
    void Start()
    {
        //OnClickGetPostAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
