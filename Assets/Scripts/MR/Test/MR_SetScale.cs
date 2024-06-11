using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_SetScale : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(0.25f,0.25f,0.25f) ;

    }
}
