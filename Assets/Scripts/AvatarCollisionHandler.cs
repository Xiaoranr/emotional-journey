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
                midiFilePlayer.MPTK_Transpose += 1;// ����������1���߼�
                
                collisionCount = 0; // ���ü�����

                if (avatarMoveScript != null)
                {
                    avatarMoveScript.SetYSpeed(0f);
                    Vector3 targetPosition = avatarTrans.position + new Vector3(0f, 0.3f, 0f);
                    avatarMoveScript.StopYMove(); // ֹͣ���� yMove
                    StartCoroutine(MoveToTargetPosition(targetPosition));
                }

            }

        
        isColliding = true;

        // ��ȡ avatarModel ��λ��
        Vector3 avatarPosition = transform.position;
        // �����������ݵ�λ��
        Vector3 bubblePosition = avatarPosition + Vector3.up * 0.1f;
        // ����Bubble
        GameObject bubble = Instantiate(collisionBubblePrefab, bubblePosition, Quaternion.identity);
        bubble.transform.parent = GameObject.Find("bubbleManager").transform;
        // ��������
        StartCoroutine(DestroyBubble(bubble, 3f));
        // ��ȡBubble�ƶ��ű�
        BubbleMovement bubbleMovement = bubble.GetComponent<BubbleMovement>();
        if (bubbleMovement != null)
        {
            // ����Bubble�����ƶ�
            bubbleMovement.SetMovingUp(true);
        }
        // �ӳ�������ײ״̬
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
        avatarMoveScript.StartYMove(); // �������� yMove
    }

    IEnumerator PrintYPosition()
    {
        yield return null; // �ȴ�һ֡��ȷ�� avatarCameraRoot ��λ�ø���
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
