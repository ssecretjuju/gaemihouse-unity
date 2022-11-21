using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HttpManager : MonoBehaviour
{
    public static HttpManager instance;

    //public string path = Application.dataPath + "/Data";
    private void Awake()
    {
        //만약에 instance가 null이라면
        if (instance == null)
        {
            //instance에 나를 넣겠다.
            instance = this;
            //씬이 전환이 되어도 나를 파괴되지 않게 하겠다.
            DontDestroyOnLoad(gameObject);
        }
        //그렇지 않으면
        else
        {
            //나를 파괴하겠다.
            Destroy(gameObject);
        }
    }

    //서버에게 요청
    //url(posts/1), GET
    public void SendRequest(HttpRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HttpRequester requester)
    {
        UnityWebRequest webRequest = null;
        //requestType 에 따라서 호출해줘야한다.
        string accessToken = PlayerPrefs.GetString("token");
        switch (requester.requestType)
        {

            case RequestType.POST:
                webRequest = UnityWebRequest.Post(requester.url, requester.postData);
                byte[] data = Encoding.UTF8.GetBytes(requester.postData);
                webRequest.uploadHandler = new UploadHandlerRaw(data);
                webRequest.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url); 
                if(accessToken != null)
                {
                    webRequest.SetRequestHeader("accesstoken", accessToken);
                }
                break;
            case RequestType.PUT:
                webRequest = UnityWebRequest.Put(requester.url, requester.postData);
                webRequest.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.DELETE:
                webRequest = UnityWebRequest.Delete(requester.url);
                break;
        }

        //서버에 요청을 보내고 응답이 올때까지 기다린다.
        yield return webRequest.SendWebRequest();

        //만약에 응답이 성공했다면
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);

            ListenData array = JsonUtility.FromJson<ListenData>(webRequest.downloadHandler.text);
            print($"테스트: {array.data[0].roomCode}가 룸 코드다");

            //JsonUtility.FromJson<PostData>(webRequest.downloadHandler.text);

            //print("키워드 데이터 갯수 :"+keywordData.data.Count);
            //완료되었다고 requester.onComplete를 실행
            if (requester.onComplete != null)
            {
                requester.onComplete(webRequest.downloadHandler);
                //File.WriteAllBytes(Application.dataPath + "/Data", webRequest.downloadHandler.data);
                //print("데이터 파일로 저장");
                //File.WriteAllText(path, webRequest.downloadHandler);
            }
            

        }
        //그렇지않다면
        else
        {
            //서버통신 실패....ㅠ
            print("통신 실패" + webRequest.result + "\n" + webRequest.error);
        }
        yield return null;
    }
}
