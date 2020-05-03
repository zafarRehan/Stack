using UnityEngine;

public class divide : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
   
        //Debug.Log(collision.collider.name);
        if(collision.transform.localScale.x == transform.localScale.x && collision.transform.localScale.z == transform.localScale.z)
            CubeCut.Cut(collision.transform, transform);
        
        //Rigidbody cuberb = newcube.cube[newcube.count-1].GetComponent<Rigidbody>();
        //cuberb.constraints = RigidbodyConstraints.FreezeAll;
    }

    
}
