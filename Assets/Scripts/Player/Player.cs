using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 2.0f;        //  �ړ����x
    [SerializeField] float crouchHeight_YScale = 0.7f;

    private float CurrentV = 0;
    private float CurrentH = 0;

    private float Interpolation = 100.0f;            //  ���
    PlayerMode CurrentPlyMode;

    Rigidbody rb;

    GameObject InputController;
    GameObject mainCamera;

    //  ���Ⴊ�݂̍���
    Vector3 crouchHeight;

    //  �ړ��@�r�b�g�t���O
    [Flags]
    private enum PlayerMode
    {
        Wark = 1 << 0,     //  0000 0001
        Run = 1 << 1,      //  0000 0010
        Crouch = 1 << 2,      //  0000 0100
        Hide = 1 << 3,     //  0000 1000
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputController = GameObject.Find("InputController");
        mainCamera = GameObject.Find("Main Camera");

        CurrentPlyMode = PlayerMode.Wark;
        crouchHeight = new Vector3(0.0f, crouchHeight_YScale, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        //  ���Ⴊ�ݒǉ�
        Crouch();

        Debug.Log(CurrentPlyMode);
    }

    //  �v���C���[�ړ����\�b�h
    private void MoveUpdate()
    {
        float moveSpeed;
        //  �L�[���͎󂯎��
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        CurrentPlyMode = PlayerModeChange();

        //  �ړ������炩�ɂ���H����ۂ�
        CurrentV = Mathf.Lerp(CurrentV, v, Time.deltaTime * Interpolation);
        CurrentH = Mathf.Lerp(CurrentH, h, Time.deltaTime * Interpolation);

        moveSpeed = Mode_SpeedChenge(MoveSpeed);
        Debug.Log(moveSpeed);

        //  �ړ�
        transform.position += transform.forward * CurrentV * moveSpeed * Time.deltaTime;
        transform.position += transform.right * CurrentH * moveSpeed * Time.deltaTime;

        //  �����󂯓n��
        //this.gameObject.transform.rotation = InputController.GetComponent<InputController>().Mouse_Rotate(this.transform.position);
        this.gameObject.transform.localEulerAngles = mainCamera.GetComponent<CameraConntroller>().Camera_GetRotate_Y();
    }

    //  �v���C���[�A�j���[�V�������\�b�h

    

    //  �v���C���[��position�n��
    public Vector3 GetPlayerPosition() 
    {
        return this.transform.position; 
    }

    //  �v���C���[���Ⴊ��
    void Crouch()
    {
        Vector3 croHeiScale = gameObject.transform.localScale;
        //  �L�[�̓t�@�X���t�H�r�A�Q�l
        if (Input.GetKeyDown(KeyCode.C))
        {
            //this.gameObject.transform.position -= crouchHeight;
            croHeiScale -= crouchHeight;
            this.gameObject.transform.localScale = croHeiScale;
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            //this.gameObject.transform.position += crouchHeight;
            croHeiScale += crouchHeight;
            this.gameObject.transform.localScale = croHeiScale;
        }
    }

    PlayerMode PlayerModeChange()
    {
        PlayerMode plyMode;
        
        if (Input.GetKey(KeyCode.C))       // ���Ⴊ�ޏ��
        {
            plyMode = PlayerMode.Crouch;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))            //  ������
        {
            plyMode = PlayerMode.Run;
        }
        else if(Input.GetKey(KeyCode.F))        //   �B�����(����L�[�H)
        {
            plyMode =PlayerMode.Hide;
        }
        else�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//  �������
        {
            plyMode = PlayerMode.Wark;         
        }

        return plyMode;
    }

    //  �v���C���[�̏�Ԃɂ���ăX�s�[�h��ω�������
    float Mode_SpeedChenge(float moveSpeed)
    {
        float speed = moveSpeed;
        switch (CurrentPlyMode)
        {
            case PlayerMode.Wark:
                speed *= 1;
                break;
            case PlayerMode.Run:
                speed *= 2;
                break;
            case PlayerMode.Crouch:
                speed /= 2;
                break;
            case PlayerMode.Hide:
                speed = 0;
                break;
            default:
                break;
        }

        return speed;
    }

}
