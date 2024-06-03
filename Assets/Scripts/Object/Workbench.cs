using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.UIElements.ToolbarMenu;

public class Workbench : MonoBehaviour
{
    [SerializeField] private float Wood_AcquisitionSpan = 1.0f;

    [SerializeField] Lumberyard lumberyard;

    private int woodCount = 0;

    private int MaxNum = 99;
    private int MinNum = 0;

    private float delta;

    /// <summary>
    /// �؂̍쐬���\�b�h
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerStay(Collider collider)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.Wood_AcquisitionSpan)
        {
            this.delta = 0;

            if (MinNum <= woodCount && woodCount < MaxNum && lumberyard.GetCount() - 5 >= 0) 
            {
                woodCount++;
                //  �؂̃J�E���g��ύX
                lumberyard.SetCount(-5);
                Debug.Log("OK");
            }
        }
    }


    /// <summary>
    /// �؍ނ̐���n��
    /// </summary>
    /// <returns></returns>
    public int Get_WoodCount()
    {
        return woodCount;
    }
}
