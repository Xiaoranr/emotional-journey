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
            Debug.Log("* ��ײ");
            //�ı��ٶ�
            midiFilePlayer.MPTK_Speed = 1.5F;
            //�ı�����
            //midiFilePlayer.MPTK_Transpose = -2;
            //�ı����beats (1 = Quarter Note, 2 = Eighth Note)
            //midiFilePlayer.MPTK_Quantization = 1;

        }
    }

    }
