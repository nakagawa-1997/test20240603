using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Collider[] ItemAvailableColl;  //  �擾�\ / �擾�����𖞂����I�u�W�F�N�g
    [SerializeField] private float RayMaxDistance = 100.0f;

    [SerializeField] GameObject ItemController;

    private void Start()
    {
        //  gameobject�̒��g��n�����n����悤�R�Â��Ă���
        ItemController = GameObject.Find("ItemController");

        for (int i = 0; i < ItemAvailableColl.Length; i++)
        {
            ItemAvailableColl[i].GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  ���C���J�����̈ʒu
        Vector3 rayOriginPos = Camera.main.transform.position;

        //  Raycast���΂�����(main�̃J�����������Ă������)
        Vector3 rayDestPos= Camera.main.transform.forward;


        //  �}�E�X�����N���b�N�������Ray���΂�
        if (Input.GetMouseButton(0))
        {
            //  Ray���쐬
            Ray ray = new Ray(rayOriginPos, rayDestPos);
            //  Ray�̏Փ˔���I�u�W�F�N�g
            RaycastHit hit;

            for (int i = 0; i < ItemAvailableColl.Length; i++)
            {
                //  Ray�̒��������߂āA���܂����s�������H
                if (ItemAvailableColl[i].Raycast(ray, out hit, RayMaxDistance))
                {
                    transform.position = ray.GetPoint(RayMaxDistance);

                    //  �I�u�W�F�N�g�ʂɍs������������̂Ɂw hit.collider.tag == "����" �x�̂悤�� tag �Ŕ��肷�邱�Ƃ��\
                    if (hit.collider.tag == "red")
                    {
                        Debug.Log("�ԐF�̔���G����");

                        GameObject item = Instantiate()
                    }
                    if (hit.collider.tag == "yellow")
                    {
                        Debug.Log("���F�̔���G����");
                    }
                    if (hit.collider.tag == "blue")
                    {
                        Debug.Log("�F�̔���G����");
                    }
                }
            }

            //  Ray��\��
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

    }
}
