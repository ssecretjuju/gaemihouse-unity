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
//�̹��� ���¹� sprite?

[Serializable]
public class SearchInfo
{
    public string searchText;
}
public class PredictBoardManager : MonoBehaviour
{

    public InputField searchText;

    //��ư�� ������ �� �˻��� �ؽ�Ʈ�� �����ϰ� �ʹ�.
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
