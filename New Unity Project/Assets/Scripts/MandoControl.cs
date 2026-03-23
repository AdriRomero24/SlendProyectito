using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoControl : MonoBehaviour
{
     public float sensibilidadcam = 1.0f;
     
     public float LimiteCamY = 45.0f;

      public Transform camara;
   
     private float rotationm;

     public bool mandoConectado;

     public float velocidadrotacion = 1.0f;

    // Update is called once per frame
    void Update()
    {

        string[] mandos = Input.GetJoystickNames();

      
        if (Input.GetKeyDown("JoystickButton6") )
        {
            if (!mandoConectado)
            {
                mandoConectado = true;
                
            }
        }else 
        {
            mandoConectado = false;
        }

       if (mandoConectado){
        // Roatcion de la camara

       rotationm += Input.GetAxis("JoyY") * sensibilidadcam  - 0.4f * Time.deltaTime;
       

       rotationm = Mathf.Clamp(rotationm, -LimiteCamY, LimiteCamY) ;
       
       camara.localRotation = Quaternion.Euler(rotationm, 0, 0);
        

       // Rotación del jugador

       float rotationY = Input.GetAxis("Joy X");
     
      

      transform.Rotate(new Vector3(0, rotationY * velocidadrotacion * Time.deltaTime, 0));

    }

    }
}
