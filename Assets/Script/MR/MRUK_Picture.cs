using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;
using System;

public class MRUK_Picture : MonoBehaviour
{
    public GameObject grab;

    private void OnTriggerEnter(Collider other)
    {
        Transform parentTransform = other.gameObject.transform.parent;

        if (parentTransform != null)
        {
            MRUKAnchor anchor = parentTransform.GetComponent<MRUKAnchor>();

            if (anchor != null && anchor.HasLabel("OTHER"))
            {
               // Debug.Log("INSIDE");
                Destroy(grab);

                Vector3 SurfacePosition;
                anchor.GetClosestSurfacePosition(this.gameObject.transform.position, out SurfacePosition);

                transform.position = SurfacePosition;


                Quaternion anchorRotation = parentTransform.rotation;
                Quaternion adjustedRotation = Quaternion.Euler(anchorRotation.eulerAngles.x - 90, anchorRotation.eulerAngles.y, anchorRotation.eulerAngles.z);

                transform.rotation = adjustedRotation;

                // transform.SetParent(parentTransform);
            }
            else
            {
                Debug.Log("no parent");
            }

        }
        else
        {
            Debug.Log("no parent");
        }
    }
}
