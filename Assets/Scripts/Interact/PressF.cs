using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressF : MonoBehaviour
{
    //플레이어가 특정 사물에 다가갔을때 F키를 눌러 실행 문구가 뜬다.

    bool onPlayer = false;
    public GameObject interObject;
    public GameObject popUpImage;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(onPlayer == true)
        {
            popUpImage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                interObject.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //만약 충돌한 것이 플레이어라면
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            onPlayer = false;
        }
    }
}

