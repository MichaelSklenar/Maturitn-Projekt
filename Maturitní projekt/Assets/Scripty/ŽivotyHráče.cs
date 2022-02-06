using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ŽivotyHráče : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float PočetŽivotů;
    public float currentHealth { get; private set; }
    private Animator animace;
    private bool Mrtvý;

    [Header("iFrames")]
    [SerializeField] private float NedotknutelnostČas;
    
    private void Awake()
    {
        currentHealth = PočetŽivotů;
        animace = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, PočetŽivotů);//maximální počet životů
        if (currentHealth > 0)
        {

            animace.SetTrigger("Poškození");

            //muže byt poškozen
        }
        else
        {
            if (!Mrtvý)
            {
              
                //hráč
                FindObjectOfType<GameManager>().KonecHry();
                FindObjectOfType<PohybHráče>().Znehybnit();
                animace.SetTrigger("Smrt");
                
                Mrtvý = true;
            }
        
        }
    }
    

}
