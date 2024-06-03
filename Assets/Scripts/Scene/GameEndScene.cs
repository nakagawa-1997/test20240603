using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameEndScene : MonoBehaviour
{
    //Inspector����l��ύX���������A���̃N���X����̏���������h����������
    [SerializeField] private GameObject GameClearUI;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private TextMeshProUGUI Timer_Text;
    [SerializeField] private TextMeshProUGUI Result_Text;

    private float Timer_Result;
    private bool clearflg;

    private void Start()
    {
        //  �����������ԓn��
        Timer_Result = UIController.Get_Timer();

        //  �N���A�t���O�n��
        clearflg=MainScene.Get_clearFlg();


        //  �����������ԏ����o��
        Timer_Text.text = "Time�F" + Timer_Result.ToString("n2");

        //  �w�i�ω�
        if (clearflg == true)
        {
            //UI�̕\���𖳌���
            GameOverUI.SetActive(false);


            //  �����������Ԃɂ���ď̍��̃e�L�X�g��ς���
            if (0f < Timer_Result && Timer_Result <= 40f)           //  �����������Ԃ�0�`50�܂ł̊ԂȂ�
            {
                Result_Text.text = "���Ȃ���...�x�e�����z�B��";
            }
            else if (40f < Timer_Result && Timer_Result <= 70f)
            {
                Result_Text.text = "���Ȃ���...��ʔz�B��";
            }
            else if (70f < Timer_Result && Timer_Result <= 90f)
            {
                Result_Text.text = "���Ȃ���...�V�l�z�B��";
            }
            else
            {
                Result_Text.text = "���Ȃ���...�A���o�C�^�[";
            }
        }
        else if (clearflg == false) 
        {
            //UI�̕\���𖳌���
            GameClearUI.SetActive(false);

            //  ���ʂ�\��
            Result_Text.text = "���Ȃ���...���������Ă��܂���";
        }

    }
}
