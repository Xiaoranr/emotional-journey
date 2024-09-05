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
        // 获取手柄位移
        Vector3 leftHandDisplacement = leftHandAnchor.position - initialLeftHandPosition;
        //Vector3 rightHandDisplacement = rightHandAnchor.position - initialRightHandPosition;

        // 计算移动方向
        Vector3 movementDirection = leftHandDisplacement;
        movementDirection.z = 0f;  // 将移动方向的 Z 分量设为 0

        // 根据移动方向控制 Avatar 的移动
        Vector3 movement = movementDirection * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
