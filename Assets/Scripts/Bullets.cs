using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    [SerializeField] float velocidad = 5;
    float zLimit = 66;
    float xLimit = 80;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        if(transform.position.z > zLimit || transform.position.z < -  zLimit)
        {
            gameObject.SetActive(false);
        }

        if(transform.position.x < - xLimit || transform.position.x > xLimit)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name);
        Salud salud = other.GetComponent<Salud>();

        if(salud != null)
        {
            salud.perderSalud();
        }
        gameObject.SetActive(false);
    }
}
