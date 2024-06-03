using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChengeItem;

public class ItemUseJug : MonoBehaviour
{
    [SerializeField] GameObject ItemController;
    [SerializeField] GameObject flashLight;

    private bool IsClick_Memo = false;
    private GameObject memoAnime;



    // Start is called before the first frame update
    void Start()
    {
        //  gameobject�̒��g��n�����n����悤�R�Â��Ă���
        ItemController = GameObject.Find("ItemController");
        flashLight = GameObject.Find("FlashLight_spotLight");

    }

    // Update is called once per frame
    void Update()
    {
        //  tag���󂯎��
        string playerItem;
        playerItem = ItemController.GetComponent<ChengeItem>().GetItemActiveTagName();

        //  �g���L�[�i�}�E�X�̉E�N���b�N�j�������ꂽ���ǂ���
        if (Input.GetMouseButtonDown(1))    //  �E�N���b�N
        {
            //�����ꂽ�ꍇ

            //  �A�C�e���ʂœ�����ω�������
            switch (playerItem)
            {
                case "hand":
                    Debug.Log("�A�C�e���F�Ȃ��@�E�N���b�N");

                    break;
                case "key":

                    Debug.Log("�A�C�e���F�J�M�@�E�N���b�N");
                    //  �����ڂ̑O�Ɍ��̂��������������邩����@����ꍇ�i���̌����g������������A�������b�N��������j�@�Ȃ��ꍇ�i�Ȃɂ��Ȃ��ƕ\���j
                    break;
                case "flashLight":

                    Debug.Log("�A�C�e���F�����d���@�E�N���b�N");
                    //  �����d�����d�C��ON/OFF�@
                    if (flashLight.activeSelf == true)
                    {
                        flashLight.SetActive(false);
                    }
                    else if (flashLight.activeSelf == false)
                    {
                        flashLight.SetActive(true);
                    }
                    break;
                case "memo":

                    Debug.Log("�A�C�e���F�����@�E�N���b�N");
                    IsClick_Memo = true;

                    break;

            }
        }
        else
        {
            //  ������Ȃ������ꍇ
            IsClick_Memo = false;
            //  �����Ȃ�
        }
    }

    public bool GetIsClick_MemoFlag()
    {
        return IsClick_Memo;
    }
}
