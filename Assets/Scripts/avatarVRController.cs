using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class avatarVRController : MonoBehaviour
{
    public Transform leftHandAnchor;
    //public Transform rightHandAnchor;
    public float movementSpeed = 1f;

    private Vector3 initialLeftHandPosition;
   // private Vector3 initialRightHandPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialLeftHandPosition = leftHandAnchor.position;
        //initialRightHandPosition = rightHandAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ�ֱ�λ��
        Vector3 leftHandDisplacement = leftHandAnchor.position - initialLeftHandPosition;
        //Vector3 rightHandDisplacement = rightHandAnchor.position - initialRightHandPosition;

        // �����ƶ�����
        Vector3 movementDirection = leftHandDisplacement;
        movementDirection.z = 0f;  // ���ƶ������ Z ������Ϊ 0

        // �����ƶ�������� Avatar ���ƶ�
        Vector3 movement = movementDirection * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
