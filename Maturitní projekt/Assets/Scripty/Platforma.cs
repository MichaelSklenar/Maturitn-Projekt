using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma : MonoBehaviour
{
    private Vector3 poziceA;
    private Vector3 poziceB;
    private Vector3 Dal��Pozice;

    [SerializeField] private float rychlostPlatfromy;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        poziceA = childTransform.localPosition;
        poziceB = transformB.localPosition;
        Dal��Pozice = poziceB;
    }
    void Update()
    {
        Pohyb();
    }

    private void Pohyb()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, Dal��Pozice, rychlostPlatfromy * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, Dal��Pozice) <= 0.1)
        {
            N�vrat();
        }
    }
    private void N�vrat()
    {
        Dal��Pozice = Dal��Pozice != poziceA ? poziceA : poziceB;
    }
}
