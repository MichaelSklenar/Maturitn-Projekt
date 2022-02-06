using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcházeníPlatformou : MonoBehaviour
{
    private PlatformEffector2D Procházení;
    public float Čekání;
    private void Start()
    {
        Procházení = GetComponent<PlatformEffector2D>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Čekání = 0.5f;
        }
            if (Input.GetKey(KeyCode.S))
        {
            if (Čekání <= 0)
            {
                Procházení.rotationalOffset = 180f;
                Čekání = 0.5f;
                if(Time.deltaTime > 0.1f)
                {
                    Procházení.rotationalOffset = 0;
                }
                
            }
            else
            {
                Čekání -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Procházení.rotationalOffset = 0;
        }
       
    }
}
