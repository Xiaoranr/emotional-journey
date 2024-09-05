using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float upwardSpeed = 1f;  // 向上移动的速度
    public float waveSpeed = 1f;  // 水波的速度
    public float waveAmplitude = 0.5f;  // 水波的振幅
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
            // 更新气泡的位置，使其向上移动
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
