using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageCreationLocation : MonoBehaviour
{

    [SerializeField] Lumberyard lumberyard;

    [SerializeField] private GameObject BoxPrefab;

    [SerializeField] private float Box_AcquisitionSpan = 5.0f;

    GameObject BoxObj;

    //  �������݂��Ă��邩�ǂ����t���O
    private bool boxFlag;
    private float delta;



    private void Update()
    {
        ExistCheckObject();
    }

    /// <summary>
    /// �����쐬���郁�\�b�h
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerStay(Collider collider)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.Box_AcquisitionSpan && boxFlag == false)
        {
            this.delta = 0;

            if (lumberyard.GetCount() - 5 >= 0 )
            {
                //  �؂̃J�E���g��ύX
                lumberyard.SetCount(-5);
                Debug.Log("YES");

                //  ���쐬
                GameObject BoxObj = Instantiate(BoxPrefab);
                BoxObj.transform.position = new Vector3(30.0f, 8.0f, 20.0f);
            }
        }
    }


    /// <summary>
    /// �I�u�W�F�N�g�����݂��邩���m�F
    /// </summary>
    private void ExistCheckObject()
    {
        if (BoxPrefab)
        {

            Debug.Log(false);
            boxFlag = false;

        }
        else
        {
            Debug.Log(true);
            boxFlag = true;
        }
    }
}
