using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //  ��]���x
    [SerializeField] public float X_RotationSpeed = 500f;

    private Vector3 StartMousePosition = Vector3.zero;      //  �}�E�X�̍ŏ��̈ʒu
    private Vector3 CurrentMousePosition = Vector3.zero;      //  �}�E�X�̌��݈ʒu
    private Vector3 StartCameraRotation = Vector3.zero;     //  �J�����̍ŏ��̊p�x
    private Vector3 CurrentCameraRotation = Vector3.zero;     //  �J�����̌��݂̊p�x

    private void Update()
    {
        MouseCursorFormat();
    }


    //  ���݂̃}�E�X�̈ʒu���X�V���郁�\�b�h
    public void Get_CurrentMousePosition_Update()
    {
        //  �}�E�X�̌��݈ʒu�ƃJ�����̊p�x���擾�i�����n�_�̐ݒ�j
        CurrentMousePosition = Input.mousePosition;
        CurrentCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;
    }

    //  �ŏ��̃}�E�X�̈ʒu���X�V���郁�\�b�h
    public void Get_StartMousePosition_Update()
    {
        //  �}�E�X�̌��݈ʒu�ƃJ�����̊p�x���擾�i�����n�_�̐ݒ�j
        StartMousePosition = Input.mousePosition;
        StartCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;
    }

    //  ���݂̃}�E�X�ʒu��Ԃ����\�b�h
    public Vector3 Get_CurrentMousePosition()
    {
        return CurrentMousePosition;
    }

   

    //  �}�E�X�̉�]
    public Quaternion Mouse_Rotate(Vector3 point)
    {
        //  �}�E�X�̈ړ���
        float mouseInputX = Input.GetAxis("Mouse X");

        //  point�𒆐S��y����]
        transform.RotateAround(point, Vector3.up, mouseInputX * Time.deltaTime * X_RotationSpeed);    //  RotateAround( ���S�Ƃ�����W , ���S�Ƃ��鎲 , ��]�p�x )
        
        return transform.rotation;
    }

    //  �}�E�X�J�[�\���̈ʒu������������
    private void MouseCursorFormat()
    {
        Cursor.lockState = CursorLockMode.None; //�}�E�X�J�[�\���̐ݒ�����������āA
        Cursor.visible = true; //�}�E�X�J�[�\����\������
    }

    //  �{�^��(�L�[�{�[�h)�������ꂽ��


    /*
    //  �������v�Z���郁�\�b�h
    public Quaternion Mouse_Rotate(Vector3 playerPos)
    {
        //  �}�E�X�̈ړ���
        float mouseInputX = Input.GetAxis("Mouse X");

        //  �}�E�X�̌��݈ʒu�ƃJ�����̊p�x���擾
        CurrentMousePosition = Input.mousePosition;
        CurrentCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;

        //  �����ʒu����̍����Z�o
        var def = (CurrentMousePosition - StartMousePosition);
        //  ��]�p�x�̎Z�o
        CurrentCameraRotation.y = StartCameraRotation.y - (-def.x * Y_RotationSpeed * 0.05f);       //  ���E�̉�]�iy��Rotation�j

        return Quaternion.Euler(CurrentCameraRotation);
    }
    */

}
