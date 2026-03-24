using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaIA : MonoBehaviour
{
   public bool probando;

   public bool valido = true;

   public bool escondido = true;

   public Transform jugador;

    private void OnWillRenderObject()
    {
        if (probando)
        {
            
           RaycastHit hit;

           if(Physics.Raycast(jugador.position, (base.transform.position - jugador.position).normalized, out hit ) && hit.collider.gameObject == base.gameObject)
            {
                escondido = false;
            }

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (probando)
        {
            
            valido = false;
        }
    }
}
