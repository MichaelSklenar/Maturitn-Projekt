using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÚtokHráče : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private Transform BodStřely;
    [SerializeField] private GameObject[] Boty;
    private Animator animace;
    private PohybHráče PohybHráče;
    private float cooldownČasovač = Mathf.Infinity;

    private void Awake()
    {
        animace = GetComponent<Animator>();
        PohybHráče = GetComponent<PohybHráče>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)&&cooldownČasovač > cooldown)
        {
            Útok();
           
        }
        cooldownČasovač += Time.deltaTime;
    }
    private void Útok()
    {
        animace.SetTrigger("Utok");
        cooldownČasovač = 0;
        Boty[NajdiBotu()].transform.position = BodStřely.position;
        Boty[NajdiBotu()].transform.GetComponent<Projektil>().Směr(Mathf.Sign(transform.localScale.x));
    }
    private int NajdiBotu()
    {
        for (int i = 0; i < Boty.Length; i++)
        {
            if (!Boty[i].activeInHierarchy)
            {
                return i;                                         
            }   
    }
        return 0;
    }
}
