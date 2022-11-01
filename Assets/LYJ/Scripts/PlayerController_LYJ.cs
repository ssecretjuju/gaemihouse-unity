using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_LYJ : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float _speed = 5f;
    [SerializeField] public float _turnSpeed = 360f;
    private Vector3 _input;

    //이모티콘

    public Sprite[] imoticon;
    public GameObject imoticonPrefab;
    private KeyCode[] keyCodes = {
KeyCode.Alpha1,
KeyCode.Alpha2,
KeyCode.Alpha3,
KeyCode.Alpha4,
KeyCode.Alpha5,
KeyCode.Alpha6,
KeyCode.Alpha7,
KeyCode.Alpha8,
KeyCode.Alpha9,
};

    public enum State
    {
        Idle,
        Walk,
        Sit,

    }
    public State m_State;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>(); 
    }

    void Update()
    {
        GatherInput();
        Look();

            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    GameObject imo = gameObject.transform.GetChild(0).gameObject;
                    EmoDestory_LYJ emo = imo.GetComponent<EmoDestory_LYJ>();
                    emo.emoOn = true;
                    emo.checkTime = 0;
                    SpriteRenderer spriteRenderer = imo.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = imoticon[i];
                    imo.transform.parent = gameObject.transform;
                }
            }
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        if (_input == Vector3.zero)
        {
            anim.SetBool("Walking", false);
            m_State = State.Idle;
        }
        else
        {
            anim.SetBool("Walking", true);
            m_State = State.Walk;
        }

    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);

    }


}
