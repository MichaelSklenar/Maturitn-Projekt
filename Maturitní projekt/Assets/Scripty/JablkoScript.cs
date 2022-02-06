using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JablkoScript : EnemyDamage // inheritance
{
    [SerializeField] private float rychlost;
    [SerializeField] private float reset;
    
    private float lifetime;
    private Animator animace;
    private BoxCollider2D coll;

    private bool hit;

    private void Awake()
    {
        animace = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = rychlost * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > reset)
            gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); //EnemyDamage script
        coll.enabled = false;
        gameObject.SetActive(false); //deaktivace po nárazu
       
            animace.SetTrigger("exploze");                  
            gameObject.SetActive(false);
                     
     }
    private void Deaktivace()
    {
        gameObject.SetActive(false);
    }

}
