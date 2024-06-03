using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

    //  �^�C�g���V�[���؂�ւ�
    public void ChangeTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //  ���C���V�[���؂�ւ�
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    //�G���f�B���O�V�[���؂�ւ�
    public void ChangeGameEndScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    //  �Q�[�����I���
    public void GameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        #endif
            Application.Quit();//�Q�[���v���C�I��
    }
}
