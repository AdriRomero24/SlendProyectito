
using System.ComponentModel.Design;
using UnityEngine;

public class TomarHojas : MonoBehaviour
{
    public Transform jugador;

    public JugadorGeneral ply;

    public bool enrango;

    public LayerMask filtro;



   

    void Update()
    {
        
     RaycastHit hitdata;

        if (base.GetComponent<Renderer>().isVisible)
        {
           if ((float)Vector3.Distance(jugador.position, base.transform.position) <= 4.0f){
                
                if (Physics.Raycast(jugador.position, (base.transform.position - jugador.position).normalized, out hitdata, 2f, filtro))
                {
                    enrango = true;
                    ply.hojacerca = base.transform;
                }
                else if (enrango)
                {
                    enrango = false;
                    ply.hojacerca = null;
                }
            }

        } else if (enrango)
        {
            enrango = false;
            ply.hojacerca = null;

        }

        if (Input.GetMouseButtonDown (0) && enrango && Physics.Raycast(jugador.position, (base.transform.position - jugador.position).normalized, out hitdata, 2f, filtro) && hitdata.collider.gameObject == base.gameObject)
        {
            
            ply.hojas++;
            ply.spnext = true;
            ply.hojacerca = null;
            ply.muchotime = 15000;

            if (ply.hojas < 8){

                ply.nieblapunto = 0.02f + (float)ply.hojas * 0.01f;
            }
            else
            {
                ply.nieblapunto = 0.01f;
            }
            if(ply.nivel > 0)
            {
                ply.nivel--;
            }
            if (ply.hojas < 8)
            {
                ply.rangomax = 100 - (ply.hojas + ply.nivel) * 11;
                ply.rangomin = 80 - (ply.hojas + ply.nivel) * 10;
            
            }
            else
            {
                ply.rangomax = 20f;
                ply.rangomin = 10f;
                ply.delayfinal = 750;

            }





            Object.Destroy(base.gameObject);

        }

    }
}
