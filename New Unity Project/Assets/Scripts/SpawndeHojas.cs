
using System.Net;
using UnityEngine;

public class SpawndeHojas : MonoBehaviour
{
    public Transform Hoja1;

    public Transform Hoja2;

    public Transform Hoja3;

    public Transform Hoja4;

    public Transform Hoja5;

    public Transform Hoja6;

    public Transform Hoja7;

    public Transform Hoja8;

    public int CualHoja;

    public int zonas;

    public bool vald;

    private bool h1, h2, h3, h4, h5, h6, h7, h8;

    public TomarHojas tom;


    void Awake()
    {
        zonas = Random.Range(1,9);
    }


    void BuscarSpawn(Transform punto)
    {
      

       GameObject [] cine = GameObject.FindGameObjectsWithTag("SpawnHojaCine");
       int scine = cine.Length;

       GameObject [] feria = GameObject.FindGameObjectsWithTag("SpawnHojaFeria");
       int sferia = feria.Length;

       GameObject [] cir = GameObject.FindGameObjectsWithTag("SpawnHojaCir1");
       int scir = cir.Length;

       GameObject [] pasillo1 = GameObject.FindGameObjectsWithTag("SpawnHojaPasi1");
       int spasillo1 = pasillo1.Length;

       GameObject [] rombo = GameObject.FindGameObjectsWithTag("SpawnHojaRombo");
       int srombo = rombo.Length;

       GameObject [] esq = GameObject.FindGameObjectsWithTag("SpawnHojaEsq");
       int sesq = esq.Length;

       GameObject [] pb1 = GameObject.FindGameObjectsWithTag("SpawnHojaPB1");
       int spb1 = pb1.Length;

       GameObject [] pb2 = GameObject.FindGameObjectsWithTag("SpawnHojaPB2");
       int spb2 = pb2.Length;

     

       
       
       switch (zonas)
        {
            case 1:
             
              
                    
                    foreach (GameObject objc in cine)
                {
                    if (Random.value <= 1f / (float)scine)
                    {
                        punto.position = objc.transform.position;
                        punto.rotation = objc.transform.rotation;

                       Object.Destroy(objc);
                       
                       zonas++;
                       return;
                    }
                     scine--;
                     
                }
                

                 break;

            case 2:

                         foreach (GameObject objr in cir)
                {
                    if (Random.value <= 1f / (float)scir)
                    {
                        punto.position = objr.transform.position;
                        punto.rotation = objr.transform.rotation;

                       Object.Destroy(objr);
                        
                        zonas++;
                        return;
                    }
                     scir--;
                  
                }
              
                break;

               case 3:

                     foreach (GameObject objb in rombo)
                {
                    if (Random.value <= 1f / (float)srombo)
                    {
                        punto.position = objb.transform.position;
                        punto.rotation = objb.transform.rotation;

                       Object.Destroy(objb);
                       
                       zonas++;
                        return;
                    }
                     srombo--;
                    
                }
       
                
             

                break;

            
            case 4:

              foreach (GameObject objpb in pb1)
                {
                    if (Random.value <= 1f / (float)spb1)
                    {
                        punto.position = objpb.transform.position;
                        punto.rotation = objpb.transform.rotation;

                       Object.Destroy(objpb);
                            

                            zonas++;
                            return;

                    }
                     spb1--;
                     
                }
     
                break;

            case 5:

                 foreach (GameObject objp in pasillo1)
                {
                    if (Random.value <= 1f / (float)spasillo1)
                    {
                        punto.position = objp.transform.position;
                        punto.rotation = objp.transform.rotation;

                       Object.Destroy(objp);
                        
                        zonas++;
                        return;
                    }
                     spasillo1--;
                     
                }
               
                
               

                break;

            case 6:

                foreach (GameObject objpb2 in pb2)
                {
                    if (Random.value <= 1f / (float)spb2)
                    {
                        punto.position = objpb2.transform.position;
                        punto.rotation = objpb2.transform.rotation;

                       Object.Destroy(objpb2);

                       zonas++ ;
                       return;

                    }
                     spb2--;
                    
                    
                }
                    
                

                break;

            case 7:

            foreach (GameObject obje in esq)
                {
                    if (Random.value <= 1f / (float)sesq)
                    {
                        punto.position = obje.transform.position;
                        punto.rotation = obje.transform.rotation;

                       Object.Destroy(obje);
                       
                       zonas++;
                        return;
                    }
                     sesq--;
                    
                }
                
                 
                break;

            case 8: 

        
               foreach (GameObject objf in feria)
                {
                    if (Random.value <= 1f / (float)sferia)
                    {
                        punto.position = objf.transform.position;
                        punto.rotation = objf.transform.rotation;

                       Object.Destroy(objf);
                      
                      zonas = 1;
                       return;

                    }
                     sferia--;
                     
                }

            
                break;

                

        }   
      
         
       
         










    }  
      

   

    


    void FixedUpdate()
    {
        if (CualHoja >= 9)
        {
            
            return;
        }

        CualHoja = Random.Range(1,9);
       

      
       do{
        
        if (tom.spnext){

       switch (CualHoja)
        {
          case 1:

            if (!h1){
            BuscarSpawn(Hoja1);
            h1 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }

            break;
          
          case 2:
            
           if (!h2){
            BuscarSpawn(Hoja2);
            h2 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            case 3:
            
            if (!h3){
            BuscarSpawn(Hoja3);
            h3 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            case 4:
            
            if (!h4){
            BuscarSpawn(Hoja4);
            h4 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            case 5:
            
            if (!h5){
            BuscarSpawn(Hoja5);
            h5 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;


            case 6:
            
            if (!h6){
            BuscarSpawn(Hoja6);
            h6 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            case 7:
            
            if (!h7){
            BuscarSpawn(Hoja7);
            h7 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            case 8:
            
            if (!h8){
            BuscarSpawn(Hoja8);
            h8 = true;
            tom.spnext = false;
            }
            else
                {
                  CualHoja = Random.Range(1,9);
                }


            break;

            
            
             





        }
        }

         }while (h1 == false || h2 == false || h3 == false || h4 == false ||  h5 == false ||  h6 == false || h7 == false || h8 == false );

       
    }

 
       
}
