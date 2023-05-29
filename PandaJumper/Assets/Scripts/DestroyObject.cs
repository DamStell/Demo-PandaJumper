using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   


    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag.Equals("DestructObject"))
        {
            
            Destroy(collision.gameObject);
        }

    }


    

    
}
