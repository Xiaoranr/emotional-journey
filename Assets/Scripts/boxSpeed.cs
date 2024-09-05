using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class boxTempo : MonoBehaviour
{
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

        MidiFilePlayer midiFilePlayer = FindObjectOfType<MidiFilePlayer>();

        if (other.name.Equals("SadAvatar"))
        {
            Debug.Log("* 碰撞");
            //改变速度
            midiFilePlayer.MPTK_Speed = 1.5F;
            //改变音调
            //midiFilePlayer.MPTK_Transpose = -2;
            //改变节拍beats (1 = Quarter Note, 2 = Eighth Note)
            //midiFilePlayer.MPTK_Quantization = 1;

        }
    }

    }
