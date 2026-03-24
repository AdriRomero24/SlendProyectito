using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorGeneral : MonoBehaviour
{
    public bool debug;

    public int time;

    public int hojas;

    public int nivel;

    public Transform hojacerca;

    public bool spnext = true;

    public bool puedover;

    public bool atrapado;

    public bool pierde;

    public int delayfinal;

    public int asustado;

    public bool visto ;

    public GameObject sm;

    public int parpadeo;

    public bool finparpadeo;

    public bool ultimparpadeo;

    public bool pausa;

    public Light linterna;

    public float rangomax = 100f;

    public float rangomin = 80f;

    public float nieblapunto = 0.02f;

    public int muchotime = 12000;

    public float sanidad = 100f;

    public UIManager ui;
    
    public bool copiaseg;

    public bool dia;

    public float bateria = 1f;

    public Transform persecusiontest;

    public Light ojos;

    public bool linternamuriendo;

    public float drain;

    public DerrotaScript fin;
     


     


    void Update()
    {
        if (!pausa)
        {
            if (debug)
            {
                
             if (Input.GetKeyDown("f1"))
                {
                    hojas = 7;
                    rangomax = 30f;
                    rangomin = 10f;
                    nieblapunto = 0.1f;


                }

                if (Input.GetKeyDown("f2"))
                {
                    hojas = 8;
                    pierde = true;

                }
                if (Input.GetKeyDown("f3"))
                {
                    
                    muchotime = 60;
                }
    
            }

            if (Input.GetMouseButtonDown(0) && time < 1598 && time > 0)
            {
                time = 1598;
            }
            if (Input.GetKeyDown("escape"))
            {
                if (ui.iniciado)
                {
                    if (time < 1598)
                    {
                        time = 1598;
                    }
                    else if (!pierde && sanidad == 100f)
                    {
                        pausa = true;
                        Time.timeScale = 0;

                    }
                    else if (!pierde)
                    {
                        parpadeo = 3;
                    }

                }
                else if (!ui.iniciado)
                {
                    
                 copiaseg = true;
                }
             
          
            }
                 if (!pausa) // Propio
                {
                    if ((Input.GetMouseButtonDown(1) || Input.GetButtonDown("Flashlight")) && time >= 1600 && (!pierde || !dia ) )
                    {
                        if (linterna.enabled)
                        {
                            linterna.enabled = false;

                        }
                        else if (bateria > 0f)
                        {
                            linterna.enabled = true;
                        }

                        MonoBehaviour.print("Clic detectado");


                    }

                }


        }
        else if (Input.GetKeyDown("escape"))
        {
            
            pausa = false;
            Time.timeScale = 1f;
        }
        else if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 1f;
            Application.LoadLevel(0);
        }
        if (finparpadeo)
        {
            finparpadeo = false;
            ultimparpadeo = true;
        }

        
    }


    void FixedUpdate()
    {
        time++;

        if (pausa)
        {
            return;
        }

       persecusiontest.position = base.transform.position;
       Quaternion rotation = Quaternion.LookRotation(base.transform.position - sm.transform.position, Vector3.up);
       rotation.x = 0f;
       rotation.z = 0f;
       persecusiontest.rotation = rotation;
       
       if(muchotime > 0 && time >= 1600 && hojas < 8)
        {
            muchotime--;

            if(muchotime <= 0 ){
                
                muchotime = 12000;
                
            if(hojas + nivel < 9)
            {
                nivel++;
                rangomax = 100 - (hojas + nivel) * 11;
                rangomin = 80 - (hojas + nivel) * 10;
            }
            }
        }
        if (time >= 1600)
        {
            if (!linterna.enabled && ojos.range < 120f)
            {
                ojos.range += 0.15f;
                if (ojos.range >= 120f)
                {
                    ojos.range = 120f;
                }

            }
            else if (linterna.enabled)
            {
                bateria -= 1.8E-05f;  // Ajustar Nivel
                
                if (bateria <= 0.15f)
                {
                    bateria = 0f;
                    linterna.enabled = false;
                }
                if (ojos.range > 30f)
                {

                   ojos.range -= 0.5f;
                   if (ojos.range <= 30f)
                    {
                        ojos.range = 30f;
                    } 

                }
            }
            if (bateria < 0.25f && Random.value < 0.2f)
            {
                if (linternamuriendo)
                {
                    linternamuriendo = false;
                }
                else
                {
                    linternamuriendo = true;
                }

            }
            if (linternamuriendo)
            {
                linterna.intensity = bateria - 0.015f;

            }
            else
            {
                linterna.intensity = bateria;
            }
        }
        if (hojas >= 8)
        {
           dia = true;
        }
        else if (!dia){
            dia = false;
        }

        if (atrapado && !pierde)
        {
            Vector3 vector = new Vector3(sm.transform.position.x, sm.transform.position.y + 1f, sm.transform.position.z);
            Quaternion de = Quaternion.LookRotation(vector - base.transform.parent.transform.position);
            base.transform.parent.transform.rotation = Quaternion.Slerp(base.transform.parent.transform.rotation, de, Time.deltaTime * 2f);
           
        }
        if (!pierde || fin.tiemporestante > 250)
        {
            if (time >= 1600)
            {
                if (atrapado)
                {
                    sanidad -= 1f;
                    if (sanidad < 0f)
                    {
                        pierde = true;
                    }
                }
                if (!puedover && !atrapado)
                {
                    if (sanidad <= 100f)
                    {
                        sanidad += 0.1f;
                        if(sanidad > 100f)
                        {
                            sanidad = 100f;
                        }
                    }
                }
                else if (drain > 0f)
                {
                    if (!atrapado)
                    {
                        sanidad -= drain;
                    }
                    if (sanidad < 0f && !pierde)
                    {
                        pierde = true;
                    }
                }
                if (pierde)
                {
                    sanidad = 100f;
                }
                if (sanidad < 0f)
                {
                    sanidad = 0f;
                }
              
                visto = puedover;

                if (fin.tiemporestante == 0)
                {
                    if (parpadeo > 0 || finparpadeo || ultimparpadeo)
                    {
                        parpadeo--;
                        if (parpadeo == 0 && !ultimparpadeo)
                        {
                            
                            finparpadeo = true;
                        }
                        if (ultimparpadeo)
                        {
                            
                            ultimparpadeo = false;
                        }
                    }
                    
                }

                if (asustado > 0)
                {
                    asustado--;

                }
            }




        }





    }

}
