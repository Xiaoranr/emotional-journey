using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float upwardSpeed = 1f;  // �����ƶ����ٶ�
    public float waveSpeed = 1f;  // ˮ�����ٶ�
    public float waveAmplitude = 0.5f;  // ˮ�������
    private bool isMovingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMovingUp)
        {
            // �������ݵ�λ�ã�ʹ�������ƶ�
            transform.position += (Vector3.up * upwardSpeed + CalculateWaveOffset()) * Time.fixedDeltaTime;
        }
    }

    private Vector3 CalculateWaveOffset()
    {
        float waveOffset = Mathf.Sin(Time.time * waveSpeed) * waveAmplitude;
        return new Vector3(waveOffset, 0f, 0f);
    }

    public void SetMovingUp(bool movingUp)
    {
        isMovingUp = movingUp;
    }
}
