using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip[] audioClips;  
    private AudioSource audioSource;  
    private int currentClipIndex = 0;  

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClips.Length > 0)
        {
            StartCoroutine(PlayAudioClips());
        }
    }

    IEnumerator PlayAudioClips()
    {
        while (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            if (currentClipIndex == 1)
            {
                FamilyPictureSetActive();
            }

            currentClipIndex++;
        }
    }

    void FamilyPictureSetActive()
    {

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
 
            if (obj.name == "OTHER")
            {
         
                GameObject familyPicture = obj.transform.Find("Title_3DModel_FamilyPicture(PrefabSpawner Clone)").gameObject;

       
                if (familyPicture != null)
                {

                    familyPicture.SetActive(true);

                }
                else
                {
                    Debug.LogWarning("MR_SetActive component not found on the familyPicture object.");
                    return; 
                }
            }
        }


        Debug.LogWarning("Title_3DModel_FamilyPicture not found in the scene.");
    }
}
