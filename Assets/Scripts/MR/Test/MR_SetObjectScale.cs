using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_SetObjectScale : MonoBehaviour
{
    public float Scale_X;
    public float Scale_Y;
    public float Scale_Z;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(Scale_X, Scale_Y, Scale_Z) ;
    }
}
