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
        //���࿡ instance�� null�̶��
        if (instance == null)
        {
            //instance�� ���� �ְڴ�.
            instance = this;
            //���� ��ȯ�� �Ǿ ���� �ı����� �ʰ� �ϰڴ�.
            DontDestroyOnLoad(gameObject);
        }
        //�׷��� ������
        else
        {
            //���� �ı��ϰڴ�.
            Destroy(gameObject);
        }
    }

    //�������� ��û
    //url(posts/1), GET
    public void SendRequest(HttpRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HttpRequester requester)
    {
        UnityWebRequest webRequest = null;
        //requestType �� ���� ȣ��������Ѵ�.
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

        //������ ��û�� ������ ������ �ö����� ��ٸ���.
        yield return webRequest.SendWebRequest();

        //���࿡ ������ �����ߴٸ�
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);

            ListenData array = JsonUtility.FromJson<ListenData>(webRequest.downloadHandler.text);
            print($"�׽�Ʈ: {array.data[0].roomCode}�� �� �ڵ��");

            //JsonUtility.FromJson<PostData>(webRequest.downloadHandler.text);

            //print("Ű���� ������ ���� :"+keywordData.data.Count);
            //�Ϸ�Ǿ��ٰ� requester.onComplete�� ����
            if (requester.onComplete != null)
            {
                requester.onComplete(webRequest.downloadHandler);
                //File.WriteAllBytes(Application.dataPath + "/Data", webRequest.downloadHandler.data);
                //print("������ ���Ϸ� ����");
                //File.WriteAllText(path, webRequest.downloadHandler);
            }
            

        }
        //�׷����ʴٸ�
        else
        {
            //������� ����....��
            print("��� ����" + webRequest.result + "\n" + webRequest.error);
        }
        yield return null;
    }
}
