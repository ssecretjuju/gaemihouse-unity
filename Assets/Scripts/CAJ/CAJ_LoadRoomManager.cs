using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

//룸 정보를 받아온다
//룸 정보(이름, 수익률)에 따라 방을 만든다
//만들어진 방을 클릭할 때, JoinOrCreateRoom()으로 방을 클릭해서 참가하게 만들어준다 
public class CAJ_LoadRoomManager : MonoBehaviour
{
    //private string FilePath = "D:\[Project]5. GaemiHouse\gaemihouse-unity\Assets\Data";
    public void OnClickGetPostAll()
    {
        //서버에 방 목록 조회 요청 (shareholder-room, GET)

        //HttpRequester 를 생성
        HttpRequester requester = new HttpRequester();

        //shareholder-room , GET
        requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.requestType = RequestType.GET;

        requester.onComplete = OnCompleteGetPostAll;
        //requester.onComplete(UnityWebRequest.downloadHandler)
        //응답을 받아서 출력

        //HttpManager 에게 요청
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPostAll(DownloadHandler handler)
    {
        //PostData 에서 Json 형태를 풀어버린다
        PostData postData = JsonUtility.FromJson<PostData>(handler.text);

        //타이틀 UI에 출력
        //내용 UI에 출력
        print("조회완료");
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
