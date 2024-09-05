using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = 0;

        if (Input.GetKey(KeyCode.W))
        {            
            ySpeed = 1;
        }

        this.transform.Translate(0, ySpeed * Time.deltaTime, 0 , Space.Self);


        if (Input.GetKey(KeyCode.S))
        {
            ySpeed = -1;
        }

        this.transform.Translate(0, ySpeed * Time.deltaTime, 0, Space.Self);

        float xSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = 1;
        }

        this.transform.Translate(xSpeed * Time.deltaTime, 0, 0, Space.Self);


        if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -1;
        }

        this.transform.Translate(xSpeed * Time.deltaTime, 0, 0, Space.Self);
    }

        
    }
