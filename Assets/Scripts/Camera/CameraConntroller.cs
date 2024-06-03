using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraConntroller : MonoBehaviour
{
    [SerializeField] private float CameraHeight_Y = 0.5f;
    //  ��]���x
    [SerializeField] private float Y_RotationSpeed = 500f;
    [SerializeField] private float MaxRotateLimit;
    [SerializeField] private float MinRotateLimit;

    //private Vector3 Camera_PlayerDistance = new Vector3(-0.2f, 2f, -0f);        //  �J�����ƃv���C���[�̋���
    private Vector3 Camera_PlayerDistance = new Vector3(-0.2f, 2f, -7f);

    //bool MoveMouseFlag;                 //  �}�E�X�����������ǂ����̃t���O

    //  ���̓R���g���[���[
    GameObject InputController;

    GameObject Player;

    private void Start()
    {
        //���̓R���g���[���[�̒��g��n�����n����悤�R�Â��Ă���
        InputController = GameObject.Find("InputController");

        Player = GameObject.Find("Player");
        
        //  �}�E�X�̌��݈ʒu�ƃJ�����̊p�x���擾�i�����n�_�̐ݒ�j
        InputController.GetComponent<InputController>().Get_StartMousePosition_Update();
        
        //  �}�E�X�̈ړ��t���O��false�ɂ���
        //MoveMouseFlag = false;


        Vector3 playerPosition = Player.GetComponent<Player>().GetPlayerPosition();
        Camera.main.transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Player.GetComponent<Player>().GetPlayerPosition();
        playerPosition += new Vector3(0.0f, CameraHeight_Y, 0.0f);
        Camera.main.transform.position = playerPosition;

        //  �}�E�X�̈ʒu���ړ��������ǂ����m�F
        if (InputController.GetComponent<InputController>().Get_CurrentMousePosition() != Input.mousePosition)
        {
            //  �J�����̈ʒu���ړ�������
            //InputController.GetComponent<InputController>().Mouse_Rotate(Player.transform.position);
            Camera.main.transform.position += Camera_Rotate(playerPosition, Camera.main.transform.position);

            //�@X���̉�]����𒴂��Ă����ꍇ�ő�l�A�܂��͍ŏ��l�ɖ߂�
            float localAngle_X = transform.localEulerAngles.x;
            float localAngle_Y = transform.localEulerAngles.y;

            if (localAngle_X > MaxRotateLimit && localAngle_X < 180)
            {
                localAngle_X = MaxRotateLimit;
            }
            if (localAngle_X < MinRotateLimit && localAngle_X > 180)
            {
                localAngle_X = MinRotateLimit;
            }

            Camera.main.transform.rotation = Quaternion.Euler(localAngle_X, localAngle_Y, 0.0f);
        }
        else 
        {
            //  �}�E�X�̌��݈ʒu�ƃJ�����̊p�x���擾�i�����n�_�̐ݒ�j
            InputController.GetComponent<InputController>().Get_CurrentMousePosition_Update();
        }
        Camera.main.transform.position = playerPosition;

    }


    private Quaternion CameraRotate_Y(Vector3 point)
    {
        float mouseInputY = Input.GetAxis("Mouse Y");
        //  point�𒆐S��x����]
        transform.RotateAround(point, Vector3.right, mouseInputY * Time.deltaTime * Y_RotationSpeed);

        return transform.rotation;
    }

    //  �������v�Z���郁�\�b�h
    private Vector3 Camera_Rotate(Vector3 playerPos, Vector3 cameraPos)
    {
        //  �J�����̌��ݍ��W����v���C���[�̍��W���������J�����̒��S�����_(0,0,0)�̈ʒu�ɂ���
        Vector3 cameraZero = cameraPos - playerPos;


        //  �}�E�X�̈ړ���
        float mouseInputX = Input.GetAxis("Mouse X");
        float angle_Y = mouseInputX * Time.deltaTime * InputController.GetComponent<InputController>().X_RotationSpeed;
        //  point�𒆐S��y����]
        this.transform.RotateAround(cameraZero, Vector3.up, angle_Y);    //  RotateAround( ���S�Ƃ�����W , ���S�Ƃ��鎲 , ��]�p�x )


        //  �}�E�X�̈ړ���
        float mouseInputY = Input.GetAxis("Mouse Y");
        float angle_X = mouseInputY * Time.deltaTime * Y_RotationSpeed;

        //  point�𒆐S��x����]
        this.transform.RotateAround(cameraZero, Vector3.left, angle_X);

        //  �J��������]�������܂܌��̈ʒu�ɖ߂����J�����̒��S���v���C���[�ɂ���
        cameraPos = cameraZero + playerPos;

        return cameraPos;
    }

    public Vector3 Camera_GetRotate_Y()
    {
        return new Vector3(0.0f, this.gameObject.transform.localEulerAngles.y, 0.0f);
    }
}
