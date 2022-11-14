using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectInfo
{
    public string objName;
    public int objWidth;
    public int objHeight;
    public Vector3 Position;
    public enum ObjectType
    {
        Text,
        Image,
    }
    public ObjectType objType;
    public bool upperObj;
    public byte[] image;
    public string text;
    public enum ObjectSkill
    {
        nomalObj,
        urlObj,
        changeObj,
        talkingObj,
    }
    public ObjectSkill objSkill;
    public string urlSkill;
    public byte[] changeSkill;
    public string talkingSkill;
    //애니메이션 어케해야할지 고민중
    public string textSkill;
    public byte[] imageSkill;

    public enum InteractionType
    {
        pressF,
        touch,
    }
    public InteractionType interactionType;
}

public class PressF : MonoBehaviour
{
    ObjectInfo objinfo;
    // Start is called before the first frame update
    void Start()
    {
        //objinfo = gameObject.transform.parent.GetComponent<ObjectInfo>().objectInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

