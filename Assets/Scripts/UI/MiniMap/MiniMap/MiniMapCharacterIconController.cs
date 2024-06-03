using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �~�j�}�b�v�p�̃A�C�R���Ǘ��N���X
/// </summary>
public class MiniMapCharacterIconController : MonoBehaviour
{
    [Tooltip("�~�j�}�b�v�A�C�R���̍��W")]
    Transform iconTransform;

    [Tooltip("Y���W�̒萔")]
    [SerializeField] float yPositionConstant = 0.0f;


    void Awake()
    {
        // ���W�擾
        iconTransform = this.transform;
    }


    /// <summary>
    /// �~�j�}�b�v�A�C�R���̍X�V����
    /// </summary>
    public void MiniMapIconUpdate(Vector3 _playerPos)
    {
        // �~�j�}�b�v��ł̈ʒu���v�Z
        Vector3 miniMapPos = new Vector3(_playerPos.x, yPositionConstant, _playerPos.z);

        // �~�j�}�b�v�A�C�R���̈ʒu���X�V
        iconTransform.position = miniMapPos;
    }
}