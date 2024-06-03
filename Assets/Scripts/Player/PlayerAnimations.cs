using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [SerializeField] private Player playerScript;

    [SerializeField] private GameObject BoxPrefab;


    private Vector3 CurrentPos = Vector3.zero;
    private bool boxPushFlg = false;


    private void Start()
    {
        CurrentPos=playerScript.GetPlayerPosition();
    }

    void Update()
    {

        //animator.SetBool("Running", CurrentPos != playerScript.GetPlayerPosition());
        //Debug.Log($"RunFlg:{animator.GetBool("Running")}");

        //  �����L�[���͂ő��郂�[�V�����̃t���O��؂�ւ���
        if (CurrentPos!=playerScript.GetPlayerPosition())
        {
            Debug.Log("RunSet");
            animator.SetBool("Running", true);
        }
        else
        {

            Debug.Log("RunFalse");
            animator.SetBool("Running", false);
        }

        //  ���ݒn���ēǂݍ���
        CurrentPos = playerScript.GetPlayerPosition();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxPrefab") 
        {
            Debug.Log("BoxPush");
            animator.SetBool("PushObject", true);
            boxPushFlg=true;
        }
        else
        {
            Debug.Log("BoxNOPush");
            animator.SetBool("PushObject", false);
            boxPushFlg=false;
        }
    }

    public bool Return_BoxPushFlg() { return boxPushFlg; }
}
