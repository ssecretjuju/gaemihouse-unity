using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;

//다른 플레이어를 클릭하면 팝업 윈도우가 활성화된다 -> DoublcClick 스크립트에서 함
//팝업 윈도우에 담을 플레이어 정보: 주식경력, 평균수익률
//플레이어 자신을 누르면 기능하지 않는다.

//만약 팝업창이 활성화 되면 회원정보를 가져와 연동한다.
public class PlayerInfoWindow : MonoBehaviour
{
    public string career;
    public int yieldRate;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
