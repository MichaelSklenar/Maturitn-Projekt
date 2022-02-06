using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour
{
    [SerializeField] private float Rychlost;
    private bool hit;
    private float smìr;
    private BoxCollider2D boxCollider;
    private float lifetime;
    private Animator animace;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animace = GetComponent<Animator>();

    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = Rychlost * Time.deltaTime * smìr;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animace.SetTrigger("exploze");
        if(collision.tag == "Boss")
        {
            collision.GetComponent<ŽivotyBosse>().TakeDamage(1);
        }
    }
    public void Smìr(float _smìr)
    {
        lifetime = 0;
        smìr = _smìr;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
       
      
    }
    private void Deaktivace()
    {
        gameObject.SetActive(false);
    }
}
