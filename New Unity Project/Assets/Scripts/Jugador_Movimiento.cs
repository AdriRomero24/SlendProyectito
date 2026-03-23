using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador_Movimiento : MonoBehaviour
{
   public float velocidad = 1.0f;

   public float velocidadrotacion = 1.0f;

   public float saltofuerza = 1.0f;

   public float sensibilidadcam = 1.0f;
     
     public float LimiteCamY = 45.0f;

      public Transform camara;
   
     private float rotationX;

   private bool saltofix;
   
  
   public Transform spawn;

   private Rigidbody physics;

   public UIManager Uii;

   private Vector3 PosJ;






    // Start is called before the first frame update
    void Start()
    {
        

        physics = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible =  false;

        transform.position = spawn.position;


    }

    // Update is called once per frame
    void Update()
    {
        
      // Movimiento del jugador parte 1

      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");

      PosJ = ((transform.forward * vertical) + (transform.right * horizontal)).normalized;

      
      

      // Roatcion de la camara

       rotationX += Input.GetAxis("Mouse Y") * sensibilidadcam * -1;
        

       rotationX = Mathf.Clamp(rotationX, -LimiteCamY, LimiteCamY);
       
       camara.localRotation = Quaternion.Euler(rotationX, 0, 0);
        

       // Rotación del jugador

       float rotationY = Input.GetAxis("Mouse X");
      

      transform.Rotate(new Vector3(0, rotationY * velocidadrotacion * Time.deltaTime, 0));

       


       // Salto del jugador Parte 1
        
       if (Input.GetKeyDown(KeyCode.Space) && (saltofix == false))
        {
            
         physics.AddForce(new Vector3(0, saltofuerza, 0), ForceMode.Impulse);

         saltofix = true;

    
        }

        // Pausa 

       if (Input.GetKeyDown("escape"))
{
    if (!Uii.pause) 
    {
        Uii.ShowPauseScreen();
    }
    else
    {
        Uii.UnshowPauseScreen();
    }
}

        

        
}

    void FixedUpdate()
    {

        // Movimiento del jugador parte 2 (Bug collision)
         physics.MovePosition(physics.position + PosJ * velocidad * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        // Salto de jugador Parte 2
         if (collision.gameObject.CompareTag("Terrain"))
        {

           saltofix = false; 
         
    
        }

       
    }


   

}
