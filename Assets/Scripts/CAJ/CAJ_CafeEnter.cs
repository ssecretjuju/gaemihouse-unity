using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CAJ_CafeEnter : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PhotonNetwork.LoadLevel("CAJ_CafeScene");
        }
    }
}
