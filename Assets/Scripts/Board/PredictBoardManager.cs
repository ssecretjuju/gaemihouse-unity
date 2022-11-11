using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using UnityEngine.Networking;

//inputfield 에 입력된 text값 저장하기
//저장된 text값을 연결된 DB에 보내기
//DB에 있는 값과 유니티에 입력된 text값이 일치하면 그와 일치하는 이미지값 띄우기 -> 가져오기 위한 입력버튼
//이미지 띄우는법 

[Serializable]
public class SearchInfo
{
    public string searchText;
}

[Serializable]
public class ImageUrl
{
    public int stockPredictionCode;
    public string stockPredictionName;
    public string stockPredictionImage1;
}
[System.Serializable]
public class Data
{
    public int status;
    public string message;
    public string data;
}

public class PredictBoardManager : MonoBehaviour
{

    public InputField searchText;

    //버튼을 눌렀을 때 검색한 텍스트를 저장하고 싶다.
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

    //검색했을 때 받는 이미지 주소값을 저장
    public void OnCompleteSearch(DownloadHandler handler)
    {
        Data data = JsonUtility.FromJson<Data>(handler.text);
        ImageUrl url = JsonUtility.FromJson<ImageUrl>(data.data);
        print(handler);
        Debug.Log(url.stockPredictionImage1);
        //print(imgUrl.stockPredictionImage1);
        StartCoroutine(GetTexture(img, url.stockPredictionImage1));
    }

    //저장된 이미지 주소를 텍스처화해서 띄운다.

    IEnumerator GetTexture(RawImage img, string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("url");
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
