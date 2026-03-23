using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaHoja : MonoBehaviour
{    


    public Transform hoja;

    public Transform trig;



    // Start is called before the first frame update
    void Start()
    {
        hoja.position = trig.position;
    }

    // Update is called once per frame
    void Update()
    {
        hoja.position = trig.position;
        hoja.rotation = trig.rotation;
    }
}
