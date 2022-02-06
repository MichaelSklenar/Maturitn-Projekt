using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybHráče : MonoBehaviour
{
    [SerializeField] private float rychlost;
    [SerializeField] private float SílaSkoku;
    private Animator animace;
    private Rigidbody2D postava;
    private bool NaZemi;
    int HráčLayer, PlatformaLayer;
    bool SeskočitCoroutineProbíhá = false;
    private void Start()
    {
        HráčLayer = LayerMask.NameToLayer("Hráč");
        PlatformaLayer = LayerMask.NameToLayer("Platforma");
    }
    private void Awake()
    {
        //Reference pro zjednodušení
        postava = GetComponent<Rigidbody2D>();
        animace = GetComponent<Animator>();
}
    private void Update()
    {
        float HorizontálníVstup = Input.GetAxis("Horizontal");

        postava.velocity = new Vector2(HorizontálníVstup * rychlost, postava.velocity.y);// horizontální pohyb

        if (Input.GetKey(KeyCode.Space) && NaZemi) {    //Skok
            Skok();

        }
        if (HorizontálníVstup > 0.01f) { // animace otočení
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (HorizontálníVstup < -0.01f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        animace.SetBool("běh", HorizontálníVstup != 0);
        animace.SetBool("NaZemi", NaZemi);

        if (Input.GetKey(KeyCode.S)) {
            StartCoroutine("Seskočit");
        }
        if (postava.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(PlatformaLayer, HráčLayer, true);
        }
        else if (postava.velocity.y <= 0 && !SeskočitCoroutineProbíhá)
        {
            Physics2D.IgnoreLayerCollision(PlatformaLayer, HráčLayer, false);
        }

    }
    private void Skok()
    {
        postava.velocity = new Vector2(postava.velocity.x, SílaSkoku);
        animace.SetTrigger("Skok");
        NaZemi = false;
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           
            animace.SetTrigger("Smrt");
            Znehybnit();
            
            FindObjectOfType<GameManager>().KonecHry();
            GetComponent<ŽivotyHráče>().TakeDamage(3);
        }
        else if (collision.gameObject.tag == "Plošina")
        {
            NaZemi = true;
        }
       
    }
   public void Znehybnit()
    {
        rychlost = 0;
        SílaSkoku = 0;
    }
    IEnumerator Seskočit()
    {
        SeskočitCoroutineProbíhá = true;
        Physics2D.IgnoreLayerCollision(HráčLayer, PlatformaLayer, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(HráčLayer, PlatformaLayer, false);
        SeskočitCoroutineProbíhá = false;
    }
}

   

