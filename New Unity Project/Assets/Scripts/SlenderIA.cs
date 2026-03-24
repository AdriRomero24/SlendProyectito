using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderIA : MonoBehaviour
{
    
   public Transform jugador;

   public JugadorGeneral ply;

   public int hacersalto;

   public int podriateleport;

   public bool movido;

   public Renderer model;

   public Vector3 perseguido = new Vector3(0f, 0f, 0f);

   public bool enpersecu;

   public int ocupadomover;

   public float desviacionmax = 4f;

   public UIManager uii;

   public DerrotaScript perdida;

   public PruebaIA test;

   public Transform objprueba;

   public void ChecarSanidad()
    {
        
     Vector3 vector = new Vector3(base.transform.position.x, base.transform.position.y + 1.33f, base.transform.position.z );
     float num = Vector3.Distance(vector, jugador.position);

     float drain = (ply.dia ? Mathf.Pow(2f, (0f - num / 1.5f) / 10f) : ((!ply.linterna.enabled) ? Mathf.Pow(2f, (0f - num * 2f) / 10f) : Mathf.Pow(2f, (0f - num) / 10f)));
     ply.puedover = false;

     RaycastHit hitData;
     if (Physics.Raycast(jugador.position, (vector - jugador.position).normalized, out hitData) && hitData.collider.gameObject == base.gameObject)
        {
            
            ply.puedover = true;

            if(!ply.visto && num < 10f && ply.asustado <= 0)
            {
                



                ply.visto = true;
                ply.asustado = 600;

            }
            ply.drain = drain;




        }
       






    }

    private void FixedUpdate()
    {
        if (ply.pausa)
        {
            return;
        }
        float num = 149f;
        float num2 = -149f;
        float num3 = 149f;
        float num4 = -149f;

        if (movido)
        {
            movido = false;
             
                  // pendiente flicker



        }
        if (ply.hojas + ply.nivel > 0 && perdida.tiemporestante == 0)
        {
            Vector3 vector = new Vector3(base.transform.position.x, base.transform.position.y + 0.99f, base.transform.position.z );
            float num5 = Vector3.Distance(vector, jugador.position);

            RaycastHit hitData;
            if(Physics.Raycast(jugador.position, (vector - jugador.position).normalized, out hitData) && hitData.collider.gameObject == base.gameObject && num5 <= 2f)
            {
                
                if (ply.hojas >= 8 && !model.enabled)
                {
                    model.enabled = true;

                }
            }
            if (num5 < 30f)
            {
                
                RaycastHit hitData2;
                if(Physics.Raycast(jugador.position, (vector - jugador.position).normalized, out hitData2) && hitData2.collider.gameObject == base.gameObject)
                {
                    enpersecu = true;
                    perseguido = jugador.position;
                    

                }
                
            }
            else
            {
                    enpersecu = false;

            }
            if (ply.delayfinal > 0)
            {
                ply.delayfinal--;
                if (ply.delayfinal <= 0)
                {
                    ocupadomover = 4;
                }
            }
            else if ((!ply.puedover || ply.hojas + ply.nivel >= 6) && !ply.atrapado)
            {
                
                if(model.isVisible && ply.hojas + ply.nivel < 6)
                {
                    
                    podriateleport++;
                    if((podriateleport > 100 && (double)Random.value <= 0.001) || podriateleport >= 1100)
                    {
                        
                        podriateleport = 0;
                        if ((double)Random.value <= 0.5)
                        {
                            ocupadomover = 4;
                        }
                    }
                }
                else
                {
                    podriateleport = 0;
                    hacersalto++;
                    if(hacersalto >= 550 - (ply.hojas + ply.nivel ) * 50 && (!enpersecu ||(num5 > 10f && (double)Random.value <= 0.2)))
                    {
                        
                        hacersalto = 0;
                        if(ply.hojas >= 8)
                        {
                            ocupadomover = 3;
                        }
                        else if (num5 > ply.rangomax || (double)Random.value <= 0.1)
                        {
                            ocupadomover = 4;

                        }
                        else
                        {
                            ocupadomover = 3;
                        }
                    }
                }

                bool aviso = false;
                int num6 = 0;
                Vector3 vector2 = new Vector3(0f, 0f, 0f);

                if (ocupadomover == 1)
                {
                    if (test.valido)
                    {
                        
                        if(test.escondido || ply.hojas + ply.nivel >= 6) // Pendiente bool de stamina
                        {
                            
                            vector2 = objprueba.position;
                            vector2.y = 1f;
                            base.transform.position = vector2;
                            movido = true;
                            ocupadomover = 0;
                            enpersecu = false;
                        }
                        else
                        {
                            ocupadomover = 3;
                            desviacionmax += 0.25f;
                        }
                    }
                    else
                    {
                        ocupadomover = 3;
                        desviacionmax += 0.25f;

                    }
                    objprueba.position = new Vector3(0f, -50f, 0f);
                    test.probando = false;
                    test.valido = true;
                    test.escondido = true;
                }
                else if (ocupadomover == 2)
                {
                    
                    if (test.valido)
                    {
                        if((ply.hojas + ply.nivel <= 5 && test.escondido) || ply.hojas + ply.nivel == 6 || ply.hojas >= 8 || (!test.escondido && ply.hojas + ply.nivel == 7 )){
                            

                                vector2 = objprueba.position;
                            vector2.y = 1f;
                            base.transform.position = vector2;
                            movido = true;
                            ocupadomover = 0;
                            enpersecu = false;
                        }
                        else
                        {
                            ocupadomover = 4;

                        }
                    }
                    else
                    {
                        ocupadomover = 4;
                    }
                    objprueba.position = new Vector3(0f, -50f, 0f);
                    test.probando = false;
                    test.valido = true;
                    test.escondido = true;
                }
                else if (ocupadomover == 3)
                {
                    
                    while (num6 < 30 && !aviso)
                    {
                        
                        if (num6 >= 30 || aviso)
                        {
                            continue;
                        }
                        Vector2 dentrocirculo = Random.insideUnitCircle;  //ataque
                        vector2 = vector + new Vector3(dentrocirculo.x * 30f, 0f, dentrocirculo.y * 30f);
                        float num7 = Vector3.Distance(vector, vector2);
                        float num8 = Vector3.Distance(jugador.position, vector2);
                        if (vector2.x < num && vector2.x > num2 && vector2.z < num3 && vector2.z > num4)
                        {
                            if(ply.hojas >= 8 || (!ply.linterna.enabled && !ply.dia))
                            {
                                if (num5 > 30f)
                                {
                                    if (num8 > 2f && num7 + num8 - desviacionmax <= num5 && num7 >= 20f)
                                    {
                                        aviso = true;
                                    }

                                }
                                else if (num8 > 2f && num7 + num8 - desviacionmax <= num5 && num7 >= num5 - 10f && num7 <= num5 + 10f)
                                {
                                    aviso = true;
                                }


                            }
                            else if (num5 > 30f)
                            {
                                if (num8 > 8f && num7 + num8 - desviacionmax <= num5 && num7 >= 20f)
                                {
                                    aviso = true;
                                }



                            }
                            else if (num8 > 8f && num7 + num8 - desviacionmax <= num5 && num7 >= num5 - 10f && num7 <= num5 + 10f)
                            {
                                aviso = true;
                            }
                        }
                        if (!aviso)
                        {
                            num6++;
                            desviacionmax += 0.25f;

                        }
                    }
                    if (aviso)
                    {
                        
                       objprueba.position = vector2;
                       Quaternion rotacion = Quaternion.LookRotation(objprueba.position - jugador.position, Vector3.up);
                        rotacion.x = 0f;
                        rotacion.z = 0f;
                        objprueba.rotation = rotacion;
                        test.probando = true;
                        test.valido = true;
                        test.escondido = true;
                        ocupadomover = 1;
                    }
                    else
                    {
                        desviacionmax += 0.25f;

                    }




                }
                else if (ocupadomover == 4)
                {
                    while(num6 < 30 && !aviso)
                    {
                        if (num6 < 30 && !aviso)
                        {
                            Vector2 dentrocirculo = Random.insideUnitCircle.normalized;
                            vector2 = jugador.position + new Vector3(dentrocirculo.x * ply.rangomax, 0f, dentrocirculo.y * ply.rangomax);
                            vector2.y = 2.3f;
                            float num8 = Vector3.Distance(jugador.position, vector2 );

                            if (vector2.x < num && vector2.x > num2 && vector2.z < num3 && vector2.z > num4 && num8 > ply.rangomin)
                            {
                                objprueba.position = vector2;
						Quaternion rotacion2 = Quaternion.LookRotation(objprueba.position - jugador.position, Vector3.up);
						rotacion2.x = 0f;
						rotacion2.z = 0f;
						objprueba.rotation = rotacion2;
                        test.probando = true;
                        test.valido = true;
                        aviso = true;
                            }
                            else
                            {
                                num6++;


                            }

                        }
                    }
                    if (aviso)
                    {
                        ocupadomover = 2;

                    }
                }
                else
                {
                    desviacionmax = 4f;
                }
                if (movido)
                {
                    
                                    //Pendiente flicker
                       Quaternion rotacion3 = Quaternion.LookRotation(base.transform.position - jugador.position, Vector3.up);
						rotacion3.x = 0f;
						rotacion3.z = 0f;
						base.transform.rotation = rotacion3;

                }
                if (enpersecu && !model.isVisible && !ply.atrapado)
                {
                    Quaternion rotacion4 = Quaternion.LookRotation(vector - perseguido, Vector3.up);
						rotacion4.x = 0f;
						rotacion4.z = 0f;
						base.transform.rotation = rotacion4;
                        base.transform.Translate(base.transform.forward * ((float)(ply.hojas + ply.nivel) * -0.5f + 0.5f) * Time.deltaTime, Space.World);

                        if(Vector3.Distance(vector, perseguido) <= 0.75f)
                    {
                        enpersecu = false;

                    }
                }
                else if (!ply.puedover)
                {
                    Quaternion rotacion5 = Quaternion.LookRotation(base.transform.position - jugador.position, Vector3.up);
						rotacion5.x = 0f;
						rotacion5.z = 0f;
						base.transform.rotation = rotacion5;
                }

            }
            else
            {
                
                podriateleport = 0;
                ocupadomover = 0;

                if (!ply.puedover)
                {
                    

                    Quaternion rotacion6 = Quaternion.LookRotation(base.transform.position - jugador.position, Vector3.up);
						rotacion6.x = 0f;
						rotacion6.z = 0f;
						base.transform.rotation = rotacion6;
                }
            }

        }

        if (ply.hojas >= 8 && ((!ply.atrapado && model.enabled) || perdida.tiemporestante > 1))
        {
                    // Pendiente flicker

             model.enabled = false;
             base.transform.position = new Vector3 (0f, -200f, 0f);       
        }

    }








}
