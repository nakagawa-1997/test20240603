using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class UIController : MonoBehaviour
{
    //Inspector����l��ύX���������A���̃N���X����̏���������h����������
    [SerializeField] private GameObject CountUI;
    // [SerializeField] private GameObject CreateUI;

    [SerializeField] private Lumberyard lumberyard;
    //  [SerializeField] private Workbench workbench;

    [SerializeField] private TextMeshProUGUI Item_Text;
    //  [SerializeField] private TextMeshProUGUI Create_Text;
    [SerializeField] private TextMeshProUGUI Timer_Text;


    private int Wood_Count;
    private int Create_Count;
    public static float Timer;


    void Start()
    {
        //  �ŏ��̑������Canvas��\��



        if(lumberyard == null)
        {
            Debug.Log("null");
        }

        //�J�E���g����UI�̕\���𖳌���
        CountUI.SetActive(false);
        // CreateUI.SetActive(false);

        //  �J�E���g���A�K�v�ȕϐ�
        Wood_Count = 0;
        Create_Count = 0;
        Timer = 0;
    }

    void Update()
    {

        //  �e�A�C�e���̃J�E���g�̒l������Ă���
        Wood_Count = lumberyard.GetCount();
        //  Create_Count = workbench.Get_WoodCount();

        Timer += Time.deltaTime;
        Timer_Text.text = "Timer�F" + Timer.ToString("n2");

        //  �J�E���g��0���傫���Ȃ�����؍ނ�UI��\��
        if (Wood_Count>0)
        {
            //  CountUI��\��
            CountUI.SetActive(true);
        }

        //  �J�E���g��0���傫���Ȃ������UI��\��
        if (Create_Count>0)
        {
            //  CreateUI��\��
           //  CreateUI.SetActive(true);
        }

        //  �e�L�X�g��������
        ItemDisplay(Wood_Count);
        WindowDispray(Create_Count);
    }

    public void ItemDisplay(int count)
    {
        //  �A�C�e���e�L�X�g��������
        Item_Text.text = count.ToString();
    }


    //  �E��ɖ؍ނ���肵���琁���o���ƁA������\�����郁�\�b�h���쐬
    public void WindowDispray(int ItemCount)
    {
        //  ���J�E���g��������
        // Create_Text.text = ItemCount.ToString();
    }

    public static float Get_Timer()
    {
        return Timer;
    }

}
