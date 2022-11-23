using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public Button btn;
    public GameObject PopupUI;

    // Start is called before the first frame update
    void Start()
    {
        PopupUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPopUpBtn()
    {
        PopupUI.SetActive(true);
    }
}
