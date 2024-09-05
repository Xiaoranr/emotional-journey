using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class AvatarCollisionHandler : MonoBehaviour
{
    public MidiFilePlayer midiFilePlayer;
    private int collisionCount = 0;
    public Transform avatarTrans;
    private AvatarMove avatarMoveScript;
    float moveSpeed = 2f;
    public GameObject sadAvatar;
    public GameObject avatarModel;
    public GameObject collisionBubblePrefab;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        sadAvatar = GameObject.Find("SadAvatar");
        avatarModel = GameObject.Find("avatarModel");
        avatarTrans = avatarModel.transform;
        avatarMoveScript = avatarModel.GetComponent<AvatarMove>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        collisionCount++;
        Debug.Log("Collision Count: " + collisionCount);
        midiFilePlayer.MPTK_Tempo += 1;

        

        if (collisionCount >= 10)
            {
                midiFilePlayer.MPTK_Transpose += 1;// 触发音调加1的逻辑
                
                collisionCount = 0; // 重置计数器

                if (avatarMoveScript != null)
                {
                    avatarMoveScript.SetYSpeed(0f);
                    Vector3 targetPosition = avatarTrans.position + new Vector3(0f, 0.3f, 0f);
                    avatarMoveScript.StopYMove(); // 停止调用 yMove
                    StartCoroutine(MoveToTargetPosition(targetPosition));
                }

            }

        
        isColliding = true;

        // 获取 avatarModel 的位置
        Vector3 avatarPosition = transform.position;
        // 计算生成气泡的位置
        Vector3 bubblePosition = avatarPosition + Vector3.up * 0.1f;
        // 生成Bubble
        GameObject bubble = Instantiate(collisionBubblePrefab, bubblePosition, Quaternion.identity);
        bubble.transform.parent = GameObject.Find("bubbleManager").transform;
        // 销毁气泡
        StartCoroutine(DestroyBubble(bubble, 3f));
        // 获取Bubble移动脚本
        BubbleMovement bubbleMovement = bubble.GetComponent<BubbleMovement>();
        if (bubbleMovement != null)
        {
            // 设置Bubble向上移动
            bubbleMovement.SetMovingUp(true);
        }
        // 延迟重置碰撞状态
        StartCoroutine(ResetCollisionStatus());

    }



    IEnumerator MoveToTargetPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            avatarTrans.position = Vector3.Lerp(avatarTrans.position, targetPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        avatarTrans.position = targetPosition;
        //StartCoroutine(PrintYPosition());
        avatarMoveScript.StartYMove(); // 继续调用 yMove
    }

    IEnumerator PrintYPosition()
    {
        yield return null; // 等待一帧以确保 avatarCameraRoot 的位置更新
        Vector3 relativePosition = sadAvatar.transform.InverseTransformPoint(avatarTrans.position);
        Debug.Log("relative position: " + relativePosition.y);
    }

    private IEnumerator ResetCollisionStatus()
    {
        yield return new WaitForSeconds(1f);
        isColliding = false;
    }



    private IEnumerator DestroyBubble(GameObject bubble, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bubble);
    }

}
