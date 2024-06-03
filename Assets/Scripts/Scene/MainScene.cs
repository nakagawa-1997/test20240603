using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{

    [SerializeField]
    SceneController sceneController;

    GameObject SceneController;
    GameObject Player;

    Vector3 player = new Vector3();

    //  �N���A�t���O
    private static bool clearFlag = true; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.GetComponent<Player>().GetPlayerPosition();

        //  �v���C���[��������̈ʒu�܂ŗ������Ă�����V�[����ύX
        if (player.y < -0.5f)
        {
            clearFlag = false;
            //  �V�[���Έ�
            this.sceneController.ChangeGameEndScene();
        }
        
    }

    public static bool Get_clearFlg()
    {
        return clearFlag;
    }
}