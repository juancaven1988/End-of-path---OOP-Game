using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{

    [SerializeField] int SaludInicial;
    int saludActual;

    // Start is called before the first frame update
    void Start()
    {
        saludActual = SaludInicial;
    }

    public void perderSalud()
    {
        saludActual--;
        if(saludActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}
