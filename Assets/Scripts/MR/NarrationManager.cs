using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//�����W�����ɨ̷ӯ��ޭ�Ĳ�ounity�ƥ�A
public class NarrationManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public UnityEvent[] events;

    private AudioSource audioSource;
    private int currentClipIndex = 0;

    // void Start()
    //{
    //     audioSource = GetComponent<AudioSource>();
    //
    //    if (audioClips.Length > 0 && events.Length > 0)
    //    {
    //       StartCoroutine(PlayAudioClips());
    //    }
    //}

    public void StartNarration()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClips.Length > 0 && events.Length > 0)
        {
            StartCoroutine(PlayAudioClips());
        }

    }

    IEnumerator PlayAudioClips()
    {
        while (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            yield return new WaitForSeconds(1);
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

           
            if (currentClipIndex < events.Length && events[currentClipIndex] != null)
            {
                events[currentClipIndex].Invoke();
            }

            currentClipIndex++;
        }
    }
}
