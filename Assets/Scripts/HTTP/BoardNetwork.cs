using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]

public class BoardContent
{
    //�ۼ��� �г�
    public string nickName;
    //�ۼ��� ����
    public string title;
    //�ۼ��� ����
    public string content;
}

[System.Serializable]

public class ArrayData
{
    public List<BoardContent> data;

}

[System.Serializable]
public class CardLists
{
    public string cardName;
    public string desc;
}

[System.Serializable]

public class ArrayData2
{
    public List<CardLists> data2;
}

public class BoardNetwork : MonoBehaviour
{

    public GameObject btn_add;
    public GameObject descDisplay;
    public GameObject descDisplay_cancelBtn;
    public GameObject descDisplay_OkBtn;
    public InputField input_Title;
    public InputField input_memo;


    public BoardContent contentInfo = new BoardContent();

    public List<CardLists> dataList2 = new List<CardLists>();


    //ok��ư�̶� task��ư�̶� �ٸ���?

    public void TaskBtn()
    {
        string path = UnityEngine.Application.dataPath + "/DataContent/dataContent.txt";
        //�����͸� �ҷ��´�.
        string jsonData2 = File.ReadAllText(path);
        print(jsonData2);

        //jsonData -> info
        ArrayData2 arrayData2 = JsonUtility.FromJson<ArrayData2>(jsonData2);

        //������ ����
        for (int i = 0; i <arrayData2.data2.Count; i++)
        {
            CardLists info = arrayData2.data2[i];
            dataList2.Add(info);
            print(info.cardName);
            print(info.desc);
        }

    }

    public void OnCardAddBtn()
    {
        descDisplay.SetActive(true);

        if(input_Title.text != null && input_memo.text != null)
        {
            input_Title.text = "";
            input_memo.text = "";
        }
    }

    //1.����(ok)��ư�� ������ ������ �����Ѵ�.
    //2.�۾���(cancel)��ư�� ������ ������ �ҷ��ͼ� json���� ����� json���� �ҷ��� �Ŀ� â�� ������.


    public void OnOKBtn()
    {
        //new= ������, ������ ��������
        CardLists info = new CardLists();
        info.cardName = input_Title.text;
        info.desc = input_memo.text;

        //������ �����
        dataList2.Add(info);

        ArrayData2 arrayData2 = new ArrayData2();
        arrayData2.data2 = dataList2;
        string jsonData2 = JsonUtility.ToJson(arrayData2, true);
        print(jsonData2);

        //������ ��������
        string path = UnityEngine.Application.dataPath + "/DataContent";
        {
            Directory.CreateDirectory(path);
        }
        //Text���Ϸ� ����
        File.WriteAllText(path + "/dataContent.txt", jsonData2);
    }

    public void OnDescCancelBtn()
    {
        //���� ���
        string path = UnityEngine.Application.dataPath + "/DataContent/dataContent.txt";

        //�����͸� �ҷ��´�.
        string jsonData2 = File.ReadAllText(path);
        print(jsonData2);

        //jsonData -> info
        ArrayData2 arrayData2 = JsonUtility.FromJson<ArrayData2>(jsonData2);

        //������ ����
        for(int i = 0; i < arrayData2.data2.Count; i++)
        {
            CardLists info = arrayData2.data2[i];
            print(info.cardName);
            print(info.desc);
            print(arrayData2.data2.Count);
        }

        //descDisplay.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
