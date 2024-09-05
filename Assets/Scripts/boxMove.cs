using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour
{
    float ySpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("yMove", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.6f;
        float distance = speed * Time.deltaTime;
        float dy = ySpeed * Time.deltaTime;
        this.transform.Translate(distance, 0, dy);
    }

    void yMove()
    {
        float[] options = { -0.15f, -0.08f, 0.08f, 0.15f };
        int sel = Random.Range(0, options.Length);
        ySpeed = options[sel];
    }
}
