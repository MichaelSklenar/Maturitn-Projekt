using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("útok")]
    [SerializeField] private float Cooldown;
    [SerializeField] private float range;


    [Header("støely")]
    [SerializeField] private Transform ShootPos;
    [SerializeField] private GameObject[] jablka;

    [Header("colider")]
    [SerializeField] private float colliderVzdálenost;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Layer")]
    [SerializeField] private LayerMask LayerHráèe;
    private float CooldownÈasovaè = Mathf.Infinity;

    private Animator animace;

    private void Awake()
    {
        animace = GetComponent<Animator>();
    }
    private void Update()
    {
        if (HráèvDosahu())
        {
            CooldownÈasovaè += Time.deltaTime;
            if (CooldownÈasovaè >= Cooldown)
            {
                CooldownÈasovaè = 0;
                animace.SetTrigger("utok");
            }
        }

    }
    private void Útok()
    {
        CooldownÈasovaè = 0;
        jablka[NajdiJablko()].transform.position = ShootPos.position;
        jablka[NajdiJablko()].GetComponent<JablkoScript>().ActivateProjectile();
    }
    private int NajdiJablko()
    {
        for (int i = 0; i < jablka.Length; i++)
        {
            if (jablka[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    private bool HráèvDosahu()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderVzdálenost,
        new Vector3(boxCollider.bounds.size.x * range, 20, boxCollider.bounds.size.z),
        0, Vector2.left, 0, LayerHráèe); //zorné pole
        
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderVzdálenost,
            new Vector3(boxCollider.bounds.size.x * range, 20, boxCollider.bounds.size.z));
    }

    
}
    
