using UnityEngine;

public class dropCube : MonoBehaviour {

    Rigidbody drb;
    public bool nextTouch = true;
    public static int areaCube;
    public static bool dropped;
    public static Vector3 destPosition;
    public Vector3 offset = new Vector3(0, 10f, 0);
    public Vector3 zero;

  

    void Start ()
    {
        zero = new Vector3(0, newcube.cube[newcube.count].transform.position.y, 0);
        drb = GetComponent<Rigidbody>();
        areaCube = (int)(transform.localScale.x * transform.localScale.z);
        
	}
	
	
	void Update () {
        //Debug.Log(Vector3.Distance(newcube.cube[newcube.count].transform.position, zero));

        if (Input.GetKeyDown("down") || Input.touchCount > 0 ) //|| Vector3.Distance(newcube.cube[newcube.count].transform.position, zero) < 4.5f)
        {
            if (Input.touchCount > 0)
            {
                if (nextTouch == true)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        dropped = true;
                        drb.constraints = RigidbodyConstraints.FreezeAll;
                        drb.constraints = ~RigidbodyConstraints.FreezePositionY;
                        drb.useGravity = true;
                        
                        destPosition = destPosition + offset;
                       // cubeforce.pivot = transform.position;
                        newcube.cube[newcube.count].AddComponent<GameOver>();
                        Destroy(this);
                        newcube.count++;
                        CubeCut.shrink = true;
                    
                        nextTouch = false;
                    }
                    if (touch.phase == TouchPhase.Ended)
                        nextTouch = true;
                }

            }
            else
            {
                dropped = true;
                drb.constraints = RigidbodyConstraints.FreezeAll;
                drb.constraints = ~RigidbodyConstraints.FreezePositionY;
                drb.useGravity = true;
                
                destPosition = destPosition + offset;
               // cubeforce.pivot = transform.position;
                newcube.cube[newcube.count].AddComponent<GameOver>(); 
                Destroy(this);
                newcube.count++;
                CubeCut.shrink = true;
                //Debug.Log(transform.position);

               
            }
            
        }
        
    }  
}
