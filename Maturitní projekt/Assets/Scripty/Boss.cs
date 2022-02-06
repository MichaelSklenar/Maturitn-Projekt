using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("�tok")]
    [SerializeField] private float Cooldown;
    [SerializeField] private float range;


    [Header("st�ely")]
    [SerializeField] private Transform ShootPos;
    [SerializeField] private GameObject[] jablka;

    [Header("colider")]
    [SerializeField] private float colliderVzd�lenost;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Layer")]
    [SerializeField] private LayerMask LayerHr��e;
    private float Cooldown�asova� = Mathf.Infinity;

    private Animator animace;

    private void Awake()
    {
        animace = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Hr��vDosahu())
        {
            Cooldown�asova� += Time.deltaTime;
            if (Cooldown�asova� >= Cooldown)
            {
                Cooldown�asova� = 0;
                animace.SetTrigger("utok");
            }
        }

    }
    private void �tok()
    {
        Cooldown�asova� = 0;
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
    private bool Hr��vDosahu()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderVzd�lenost,
        new Vector3(boxCollider.bounds.size.x * range, 20, boxCollider.bounds.size.z),
        0, Vector2.left, 0, LayerHr��e); //zorn� pole
        
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderVzd�lenost,
            new Vector3(boxCollider.bounds.size.x * range, 20, boxCollider.bounds.size.z));
    }

    
}
    
