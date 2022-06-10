using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{


    [SerializeField] protected List<GameObject> balas;
    [SerializeField] protected Transform[] canons;


    //ABSTRACCION
    protected virtual void Disparar() 
    {
        Debug.Log("No Implementado");
    }

    protected GameObject[] EncontrarBalas()
  
        {
            GameObject[] respuesta = new GameObject[canons.Length];

            int encontradas = 0;
            int iterador = 0;

        while (encontradas < canons.Length && iterador < balas.Count)
        {

                if (!balas[iterador].activeInHierarchy)
                {
                    respuesta[encontradas] = balas[iterador];
                    encontradas++;
                }

                iterador++;

        } 



            return respuesta;
        }
    
}
