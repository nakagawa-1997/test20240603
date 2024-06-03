using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Inspector����l��ύX���������A���̃N���X����̏���������h����������
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursorSound()
    {
        //  ����炷
        audioSource.PlayOneShot(sound1);
    }
    public void PlayButtonPushSound()
    {
        //  ����炷
        audioSource.PlayOneShot(sound2);
    }
}
