using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Reveal : MonoBehaviour
{
    public GameObject particle;
    private float timer;

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 10f)
        {
            Instantiate(particle, transform.position, transform.rotation);
            timer = 0;
        }
          
        
    }
}
