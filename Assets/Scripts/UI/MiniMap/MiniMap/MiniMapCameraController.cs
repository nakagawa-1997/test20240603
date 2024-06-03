using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �~�j�}�b�v�p�̃J�����Ǘ��N���X
/// </summary>
public class MiniMapCameraController : MonoBehaviour
{
    [Tooltip("�~�j�}�b�v�J�����̍��W")]
    Transform cameraTransform;

    [Tooltip("Y���W�̒萔")]
    [SerializeField] float yPositionConstant = 0.0f;


    void Awake()
    {
        // �����������Ƃ��āA�~�j�}�b�v�J������Transform���擾
        cameraTransform = transform;
    }


    /// <summary>
    /// �~�j�}�b�v�A�C�R���̍X�V����
    /// </summary>
    public void MiniMapCameraUpdate(Vector3 _playerPos)
    {
        // �~�j�}�b�v��ł̈ʒu���v�Z
        Vector3 miniMapPos = new Vector3(_playerPos.x, yPositionConstant, _playerPos.z);

        // �~�j�}�b�v�A�C�R���̈ʒu���X�V
        cameraTransform.position = miniMapPos;
    }
}