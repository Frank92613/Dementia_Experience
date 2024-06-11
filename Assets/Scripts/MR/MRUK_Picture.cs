using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;
using System;

//����������I����MRUK����B���Ҭ�"OTHER"��
//�N��V�ήy�нվ��Q�I������̪񪺪�
public class MRUK_Picture : MonoBehaviour
{
    //����������\�ફ��
    public GameObject GrabFunctionObject;


    private void OnTriggerEnter(Collider other)
    {
        Transform parentTransform = other.gameObject.transform.parent;//����Q�I�����骺����

        if (parentTransform != null)
        {
            MRUKAnchor anchor = parentTransform.GetComponent<MRUKAnchor>();//����Q�I��������������I(�{��Ŷ��w��Ϊ�)����


            //�P�_���������ҬO�_�O"OTHER"
            if (anchor != null && anchor.HasLabel("OTHER"))
            {

                //�R������\�ફ��
                Destroy(GrabFunctionObject);

                //������IĲ�I�̱��񪺭��������I�A�ñN����y�г]�����I
                Vector3 SurfacePosition;
                anchor.GetClosestSurfacePosition(this.gameObject.transform.position, out SurfacePosition);
                transform.position = SurfacePosition;

                //�������������ȶi��y���ഫ(MetaXR���y�Шt�PUnity���P)�A�ñN�������ȳ]���Ӥ��������
                Quaternion anchorRotation = parentTransform.rotation;
                Quaternion adjustedRotation = Quaternion.Euler(anchorRotation.eulerAngles.x - 90, anchorRotation.eulerAngles.y, anchorRotation.eulerAngles.z);
                transform.rotation = adjustedRotation;

                // transform.SetParent(parentTransform);
            }
            else
            {
                Debug.Log("not OTHER");
            }

        }
        else
        {
            Debug.Log("no parent");
        }
    }
}
