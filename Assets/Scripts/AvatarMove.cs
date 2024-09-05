using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMove : MonoBehaviour
{
    public float ySpeed = 0;
    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("yMove", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && ySpeed != 0)
        {
            float dy = ySpeed * Time.deltaTime;
            transform.Translate(0, dy, 0);
        }
    }

    void yMove()
    {
        float[] options = { -0.15f, -0.08f, 0.08f, 0.15f };
        int sel = Random.Range(0, options.Length);
        ySpeed = options[sel];
    }

    public void SetYSpeed(float speed)
    {
        ySpeed = speed;
    }

    public void StopYMove()
    {
        isMoving = false;
    }

    public void StartYMove()
    {
        isMoving = true;
    }

}
