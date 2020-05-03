using UnityEngine;

public class cubeforce : MonoBehaviour {

    public float timePeriod = 2;
    public float height = 250f;
    private float timeSinceStart;
    public static Vector3 pivot;


    Rigidbody crb;
    public float force;
    public bool left, right;

    private void Start()
    {
        force = 500f;

        left = false;
        right = true;
        crb = GetComponent<Rigidbody>();
        pivot = transform.position;
        height /= 2;
        timeSinceStart = (3 * timePeriod) / 4;
    }


    void Update()
    {
        
        if (dropCube.dropped)
        {
            Destroy(this);
        }
        if (newcube.direction == 'x')
        {
            // height = crb.transform.localScale.x * 2.5f;
            Vector3 nextPos = crb.position;
            nextPos.x = pivot.x + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
            timeSinceStart += Time.deltaTime;
            transform.position = nextPos;
        }
        else
        {
           // height = crb.transform.localScale.z * 2.5f;
            Vector3 nextPos = crb.position;
            nextPos.z = pivot.z - height - height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
            timeSinceStart += Time.deltaTime;
            transform.position = nextPos;
        }
    }



    
        


    //void Start()
    //{
    //    force = 500f;

    //    left = false;
    //    right = true;
    //    crb = GetComponent<Rigidbody>();

    //}
    //void FixedUpdate ()
    //   {
    //       if (dropCube.dropped)
    //       {

    //           Destroy(this);
    //       }
    //       if (newcube.direction == 'x')
    //       {
    //           //Debug.Log("x");
    //           if (left)
    //           {
    //               crb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    //               if (transform.position.x >= 120)
    //               {
    //                   crb.constraints = RigidbodyConstraints.FreezePositionX;

    //                   left = false;
    //                   right = true;
    //                   crb.constraints = ~RigidbodyConstraints.FreezePositionX;

    //               }
    //           }
    //           if(right)
    //           {
    //               crb.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    //               if (transform.position.x <= -120)
    //               {
    //                   crb.constraints = RigidbodyConstraints.FreezePositionX;
    //                   left = true; ;
    //                   right = false;
    //                   crb.constraints = ~RigidbodyConstraints.FreezePositionX;
    //               }
    //           }
    //          // newcube.direction = 'z';
    //       }


    //       if (newcube.direction == 'z')
    //       {
    //           //Debug.Log("z");
    //           if (left)
    //           {
    //               crb.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
    //               if (transform.position.z >= 120)
    //               {
    //                   crb.constraints = RigidbodyConstraints.FreezePositionZ;
    //                   left = false;
    //                   right = true;
    //                   crb.constraints = ~RigidbodyConstraints.FreezePositionZ;
    //               }
    //           }
    //           if (right)
    //           {
    //               crb.AddForce(0, 0, -force * Time.deltaTime, ForceMode.VelocityChange);
    //               if (transform.position.z <= -120)
    //               {
    //                   crb.constraints = RigidbodyConstraints.FreezePositionZ;
    //                   left = true; 
    //                   right = false;
    //                   crb.constraints = ~RigidbodyConstraints.FreezePositionZ;
    //               }
    //           }
    //          // newcube.direction = 'x';
    //       }

}

