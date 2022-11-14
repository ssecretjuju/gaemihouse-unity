using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using UnityEngine.Networking;

//inputfield �� �Էµ� text�� �����ϱ�
//����� text���� ����� DB�� ������
//DB�� �ִ� ���� ����Ƽ�� �Էµ� text���� ��ġ�ϸ� �׿� ��ġ�ϴ� �̹����� ���� -> �������� ���� �Է¹�ư
//�̹��� ���¹� 

[Serializable]
public class SearchInfo
{
    public string searchText;
}

[Serializable]
public class ImageUrl
{
    public int status;
    public string message;
    public string data;
}

public class PredictBoardManager : MonoBehaviour
{
    public GameObject predictCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            predictCanvas.SetActive(true);
        }
    }

    public void OnCancelBtn()
    {
        predictCanvas.SetActive(false);
    }


    public InputField searchText;

    //��ư�� ������ �� �˻��� �ؽ�Ʈ�� �����ϰ� �ʹ�.
    public void OnClickSearch()
    {
        SearchInfo data = new SearchInfo();
        data.searchText = searchText.text;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://3.34.133.115:8080/stock-prediction/" + searchText.text;
        requester.requestType = RequestType.POST;
        print("test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        ///////////
        requester.onComplete = OnCompleteSearch;
        HttpManager.instance.SendRequest(requester);

    }

    public RawImage img;
    string ss;

    //�˻����� �� �޴� �̹��� �ּҰ��� ����
    public void OnCompleteSearch(DownloadHandler handler)
    {
        ImageUrl url = JsonUtility.FromJson<ImageUrl>(handler.text);
        print(url.data);

        ss = url.data;
        
        StartCoroutine(GetTexture());

    }

    //����� �̹��� �ּҸ� �ؽ�óȭ�ؼ� ����.
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(ss);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}



