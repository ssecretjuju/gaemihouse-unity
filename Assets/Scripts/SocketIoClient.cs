using UnityEngine;
using WebSocketSharp;

public class SocketIoClient : MonoBehaviour
{
    private WebSocket m_WebSocket;

    void Start()
    {
        m_WebSocket = new WebSocket("ws://localhost:8000");
        m_WebSocket.Connect();

        m_WebSocket.OnMessage += (sender, e) =>
        {
            Debug.Log($"{((WebSocket)sender).Url}에서 + 데이터 : {e.Data}가 옴.");
        };
    }

    void Update()
    {
        if (m_WebSocket == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_WebSocket.Send("안녕");
        }
    }
}