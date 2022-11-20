using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;



namespace Rextester
{

    using Newtonsoft.Json;
    public class Program
    {
        class Item
        {
            public int status;
            public string message;
            public List<Room> data;
        }

        class Room
        {
            public int roomCode;
            public string roomTitle;
            public int roomLimitedNumber;
            public int roomRegistedNumber;
            public double roomYield;
        }

        public static void Main(string[] args)
        {
            Debug.Log("Hello, world!");

            string jsonData = "{" +
                              "\"status\": 200," +
                              "\"message\": \"successful\"," +
                              "\"data\": [" +
                              "{" +
                              "\"roomCode\": 9999," +
                              "\"roomTitle\": \"test\"," +
                              "\"roomLimitedNumber\": 15," +
                              "\"roomRegistedNumber\": 1," +
                              "\"roomYield\": 0" +
                              "}," +
                              "{" +
                              "\"roomCode\": 9998," +
                              "\"roomTitle\": \"��������;��\"," +
                              "\"roomLimitedNumber\": 13," +
                              "\"roomRegistedNumber\": 1," +
                              "\"roomYield\": 0" +
                              "}" +
                              "]" +
                              "}";

            JObject jObject = JObject.Parse(jsonData);

            List<Room> roomList = JsonConvert.DeserializeObject<Item>(jsonData).data;

            foreach (Room room in roomList)
            {
                Debug.Log(room.roomTitle + ", " + room.roomLimitedNumber + ", " + room.roomRegistedNumber + ", " + room.roomYield);
            }
        }
    }
}


//�ؾ��� ��
//1. �� ���� �޾ƿ���
//2. �� ������ ����Ʈ �����? Dictionary?
//3. ���� �� ������ �� �����
//4. ���� �濡 �� ���� �������ֱ� 

// ������ ��, �� ����� ����
// �� Ŭ���ϸ�, JoinOrCreateRoom()���� �� ����! 


public class NewRoomListSetting : MonoBehaviour
{
    public GameObject roomItemFactory;
    public List<Transform> spawnPos;


    //���� ������   
    //Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    void CreateRoomList()
    {
        int count = 0;
        //foreach (RoomInfo info in roomCache.Values)
        {
        GameObject go = Instantiate(roomItemFactory, spawnPos[count]);
        RoomItem item = go.GetComponent<RoomItem>();
        //item.SetInfo(info);
        }
        count++;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
        CreateRoomList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://3.34.133.115:8080/shareholder-room");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(System.Text.Encoding.Default.GetString(request.downloadHandler.data));
            RoomData roomdata = JsonUtility.FromJson<RoomData>(System.Text.Encoding.Default.GetString(request.downloadHandler.data));
            //Show results as text
           //Debug.Log(request.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = request.downloadHandler.data;
        }
    }

}
