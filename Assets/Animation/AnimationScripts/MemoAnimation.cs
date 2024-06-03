using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoAnimation : MonoBehaviour
{
    //  �����p
    private GameObject memo;
    [SerializeField] private float memoStopPoint_X = 0;
    [SerializeField] private float memoStopPoint_Y = 0;
    [SerializeField] private float memoStopPoint_Z = 0;

    private Animator anim = null;

    private GameObject isClick;
    private bool standBy_isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        //  �����p
        anim = GetComponent<Animator>();
        //  �Q�[���I�u�W�F�N�g�̎󂯓n���i�A�j���[�V������r���Ŏ~�߂邽�߂Ɏg�p�j
        memo = GameObject.Find("Memo");
        isClick = GameObject.Find("ItemUse");
    }

    // Update is called once per frame
    void Update()
    {
        bool clickFlag = isClick.GetComponent<ItemUseJug>().GetIsClick_MemoFlag();

        if (clickFlag == true) 
        {
            if (standBy_isClick == false) //  �ҋ@��Ԃ���Ȃ��Ȃ��
            {
                //  �����������ɏ����ꂽ�����̕\���i�Q�[�����[�v���񂷁j
                anim.SetBool("IsClick", true);

                standBy_isClick = true;
            }
            else if(standBy_isClick == true)
            {



            }


            Vector3 memo_StopPoint = new Vector3(memoStopPoint_X, memoStopPoint_Y, memoStopPoint_Z);
            //  ������x�E�N���b�N�����܂Ō�������

            //  �A�j���[�V�����ŃI�u�W�F�N�g���w��̈ʒu�܂ŗ�����A�j���[�V�������ꎞ��~������
            if (memo.transform.position == memo_StopPoint)
            {
                //  �ꎞ��~
                anim.SetFloat("MovingSpeed", 0.0f);


                if (Input.GetMouseButtonDown(1))
                {
                    //  �A�j���[�V�������ĊJ����
                    anim.SetFloat("MovingSpeed", 1.0f);
                    anim.SetBool("IsClick", false);

                }
            }

        }
        
    }

    public void IsClickedAnim()
    {
        
    }
}
