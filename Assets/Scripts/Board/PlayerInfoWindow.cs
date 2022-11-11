using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;

//다른 플레이어를 클릭하면 팝업 윈도우가 활성화된다 -> DoublcClick 스크립트에서 함
//팝업 윈도우에 담을 플레이어 정보: 주식경력, 평균수익률
//플레이어 자신을 누르면 기능하지 않는다.

public class PlayerInfoWindow : MonoBehaviour
{
    public GameObject DoubleClick;
    public Canvas playerInfoWindow;

    public Text carrerText;
    public Text yieldText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //만약 팝업창이 활성화된다면
        if(GameObject.Find("PlayerInfoWindow").GetComponent<DoubleClick>().enabled == true)
        {
            //회원정보에 저장되어있는 경력, 수익률 텍스트 동기화

        }
    }

    public void OnEscBtn()
    {
        playerInfoWindow.enabled = false;
    }
}
