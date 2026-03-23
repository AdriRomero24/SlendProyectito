
using UnityEngine;

public class TomarHojas : MonoBehaviour
{
    public Transform jugador;

    public JugadorGeneral ply;

    public bool enrango;

    public LayerMask filtro;

    public bool spnext = true;


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
            spnext = true;
            ply.hojacerca = null;





            Object.Destroy(base.gameObject);

        }
    }
}
