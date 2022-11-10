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
//이미지 띄우는법 sprite?

[Serializable]
public class SearchInfo
{
    public string searchText;
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
            requester.url = "http://13.125.89.145:8080/stock-prediction/" + searchText.text;
            requester.requestType = RequestType.POST;
            print("test");

            requester.postData = JsonUtility.ToJson(data, true);
            print(requester.postData);

            ///////////

            HttpManager.instance.SendRequest(requester);
        


    }
}
