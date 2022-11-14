// using System.Collections;
// using System.Collections.Generic;
// using Photon.Pun;
// using Photon.Realtime;
//
// public class RoomList : MonoBehaviourPunCallbacks
// {
//     // Start is called before the first frame update
//     
//     //필요한 정보 : RoomOptions, MaxPlayer, desc, map_id(삭제가능할듯?), roomName ? 
//     
//     void Start()
//     {
//         
//         
//         // 방 옵션을 설정
//         RoomOptions roomOptions = new RoomOptions();
//         // 최대 인원 (0이면 최대인원)
//         roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
//         // 룸 리스트에 보이지 않게? 보이게?
//         roomOptions.IsVisible = true;
//         // custom 정보를 셋팅
//         ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
//         //hash["desc"] = "여긴 초보방이다! " + Random.Range(1, 1000);
//         //hash["desc"] = int.Parse(inputReturn.text);
//         //hash["desc"] = float.Parse(inputReturn.text);
//         hash["desc"] = 0;
//         hash["map_id"] = Random.Range(0, mapThumbs.Length);
//         hash["room_name"] = inputRoomName.text;
//         
//         //hash["password"] = float.Parse(inputReturn.text);
//         roomOptions.CustomRoomProperties = hash;
//         // custom 정보를 공개하는 설정
//         // roomOptions.CustomRoomPropertiesForLobby = new string[] {
//         //     "desc", "map_id", "room_name", "password"
//         // };
//         roomOptions.CustomRoomPropertiesForLobby = new string[] {
//             "desc", "map_id", "room_name"
//         };
//         print(roomOptions);
//                 
//         // 방 생성 요청 (해당 옵션을 이용해서)
//         PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
