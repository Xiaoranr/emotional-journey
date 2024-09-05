using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using UnityEngine;

public class boxTranspose : MonoBehaviour
{
    public MidiFilePlayer midiFilePlayer;
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        

        if (other.name.Equals("SadAvatar"))
        {
            collisionCount++;
            Debug.Log("Collision Count: " + collisionCount);

            if (collisionCount >= 10)
            {
                midiFilePlayer.MPTK_Transpose += 1;
                collisionCount = 0; // ÖØÖÃ¼ÆÊýÆ÷
            }

        }


    }
}
