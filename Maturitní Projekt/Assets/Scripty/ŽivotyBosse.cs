using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class    ŽivotyBosse : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float PoèetŽivotù;
    public float currentHealth { get; private set; }
    private Animator animace;
    private bool Mrtvý;

    [Header("iFrames")]
    [SerializeField] private float NedotknutelnostÈas;

    private void Awake()
    {
        currentHealth = PoèetŽivotù;
        animace = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, PoèetŽivotù);//maximální poèet životù
        if (currentHealth > 0)
        {

            animace.SetTrigger("poškození");

           
        }
        else
        {
            if (!Mrtvý)
            {

              
                FindObjectOfType<GameManager>().Výhra();
               animace.SetTrigger("Smrt");
                Mrtvý = true;
            }

        }
    }
}
