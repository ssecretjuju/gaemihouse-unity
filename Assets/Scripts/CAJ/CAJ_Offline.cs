using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CAJ_Offline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.OfflineMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
