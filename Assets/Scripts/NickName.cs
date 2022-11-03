using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    public Text Name;

    void NameShow()
    {
        //hotonNetwork.NickName = Name.text;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Name.text = PhotonNetwork.NickName;
        //PhotonNetwork.NickName = Name.text;
        print(Name.text);
        //PlayerPrefs.SetString("Name");
        //print(PlayerPrefs.GetString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
