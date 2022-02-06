using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class    �ivotyBosse : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float Po�et�ivot�;
    public float currentHealth { get; private set; }
    private Animator animace;
    private bool Mrtv�;

    [Header("iFrames")]
    [SerializeField] private float Nedotknutelnost�as;

    private void Awake()
    {
        currentHealth = Po�et�ivot�;
        animace = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, Po�et�ivot�);//maxim�ln� po�et �ivot�
        if (currentHealth > 0)
        {

            animace.SetTrigger("po�kozen�");

           
        }
        else
        {
            if (!Mrtv�)
            {

              
                FindObjectOfType<GameManager>().V�hra();
               animace.SetTrigger("Smrt");
                Mrtv� = true;
            }

        }
    }
}
