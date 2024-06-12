using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationControl_FamilyPicture : MonoBehaviour
{
  
    public void FamilyPictureSetActive()
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
                    Debug.LogWarning("Title_3DModel_FamilyPicture not found in the scene.");
                    return;
                }
            }
        }
        Debug.LogWarning("Title_3DModel_FamilyPicture not found in the scene.");
    }

}
