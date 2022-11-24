// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using UnityEngine.UI;
//
// [Serializable]
// public class UserInfo
// {
//     public string id;
//     public string password;
//     public string childName;
//     public string childBirthday;
//     public string childGender;
//
//     //public int appleClearCount = 0;
//
// }
//
// public class LoginInfo
// {
//     public string id;
//     public string password;
// }
//
// //토큰 ! 
// [Serializable]
// public class PostTokenData
// {
//     public string accessToken;
// }
//
//
//
// public class NewUserSetting : MonoBehaviour
// {
//     public InputField id;
//     public InputField password;
//     public InputField childName;
//     public InputField childBirthday;
//     public Dropdown childGender;
//
//     public InputField Logid;
//     public InputField Logpassword;
//
//     
//
//     //��ư�� �������� ������ ������ �����ϰ� �ʹ�.
//
//     void Start()
//     {
//         
//     }
//
//     void Update()
//     {
//         
//     }
//
//     //회원가입
//     public void OnClickSave()
//     {
//         UserInfo data = new UserInfo();
//         data.id = id.text;
//         data.password = password.text;
//         data.childName = childName.text;
//         data.childBirthday = childBirthday.text;
//         data.childGender = childGender.options[childGender.value].text;
//
//         HttpRequester requester = new HttpRequester();
//         requester.url = "http://192.168.1.77:8801/member";
//         requester.requestType = RequestType.POST;
//         print("test");
//
//         requester.postData = JsonUtility.ToJson(data, true);
//         print(requester.postData);
//
//         ///////////
//
//         HttpManager.instance.SendRequest(requester);
//         
//     }
//
//
//     //로그인
//     public void OnClickLogin()
//     {
//         LoginInfo data = new LoginInfo();
//         data.id = Logid.text;
//         data.password = Logpassword.text;
//      
//
//         HttpRequester requester = new HttpRequester();
//         requester.url = "http://192.168.1.77:8801/login";
//         requester.requestType = RequestType.POST;
//
//         requester.postData = JsonUtility.ToJson(data, true);
//         print(requester.postData);
//
//         ///////////
//         requester.onComplete = OnCilckDownload;
//
//         HttpManager.instance.SendRequest(requester);
//         
//     }
//roomDeleteInfo data = new roomDeleteInfo();
//data.roomTitle = roomName.text;
//print("삭제하려는 방 이름 : " + roomName.text);


//HttpRequester requester = new HttpRequester();
//requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room" + roomName.text;
//print(requester.url);
//requester.requestType = RequestType.DELETE;

//requester.postData = JsonUtility.ToJson(data, true);
//print(requester.postData);


////requester.onComplete = OnCilckDownload;


//HttpManager.instance.SendRequest(requester);
//     ///
//
// }
