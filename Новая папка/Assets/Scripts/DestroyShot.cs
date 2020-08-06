using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 6)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    
            
        
    }
}
