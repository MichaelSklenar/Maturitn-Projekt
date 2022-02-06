using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma : MonoBehaviour
{
    private Vector3 poziceA;
    private Vector3 poziceB;
    private Vector3 DalšíPozice;

    [SerializeField] private float rychlostPlatfromy;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        poziceA = childTransform.localPosition;
        poziceB = transformB.localPosition;
        DalšíPozice = poziceB;
    }
    void Update()
    {
        Pohyb();
    }

    private void Pohyb()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, DalšíPozice, rychlostPlatfromy * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, DalšíPozice) <= 0.1)
        {
            Návrat();
        }
    }
    private void Návrat()
    {
        DalšíPozice = DalšíPozice != poziceA ? poziceA : poziceB;
    }
}
