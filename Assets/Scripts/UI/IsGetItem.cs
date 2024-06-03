using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class IsGetItem : MonoBehaviour
{
    //  Inspector�Ŏw�肵���܂Ƃ߂�CanvasGroup�̃A���t�@�l��ύX����
    [SerializeField] private CanvasGroup UI_Icon;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float waitTime = 0.5f;   //  ���S�ɕ\������Ă���̑҂�����

    private float alphaValue;//�ω����铧�ߗ��̒l

    //  �^�C�}�[�p
    private float countTime;

    private bool goingFlag;
    private bool ReturnFlag;
    private bool rimitTimeFlag;


    private void Start()
    {
        alphaValue = 0.0f;
        countTime = 0.0f;

        goingFlag = false;
        ReturnFlag = false;
        rimitTimeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  �g���L�[�i�}�E�X�̉E�N���b�N�j�������ꂽ���ǂ���
        if (Input.GetMouseButtonDown(1))
        {
            //  �s���t���O��true�ɂ���
            goingFlag = true;
        }

        //  �s���t���O��true�̏ꍇ
        if (goingFlag)
        {
            alphaValue = Mathf.Lerp(alphaValue, 1.0f, Time.deltaTime * speed);
            if(alphaValue>=0.98f)
            {
                //  �s���t���O�̏������Ƒҋ@�t���O�̕ύX
                goingFlag = false;
                rimitTimeFlag = true;

                alphaValue = 1.0f;
            }
        }
        else if (rimitTimeFlag)//  �ҋ@�t���O��true�̏ꍇ
        {
            if (countTime < waitTime)
            {
                //  �J�E���g���鎞�Ԃ𑝂₷
                countTime += Time.deltaTime;
            }
            else
            {
                rimitTimeFlag = false;
                ReturnFlag = true;
            }
        }
        else if (ReturnFlag)//  �A��t���O��true�̏ꍇ
        {
            alphaValue = Mathf.Lerp(alphaValue, 0.0f, Time.deltaTime * speed);
            if (alphaValue <= 0.02f)
            {
                //  �A��t���O�̏�����
                ReturnFlag = false;
                alphaValue = 0.0f;
            }
        }

        //  ���ߗ��ύX
        UI_Icon.alpha = alphaValue;
    }
}
