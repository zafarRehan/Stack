using UnityEngine;

public class CubeCut : MonoBehaviour
{
   
    public static bool shrink, gameison, perfect;
    public static int perfectCount = 0;
    public static GameObject newcub,fallcube;
    public static GameObject aud;
    private void Start()
    {
        
        shrink = false;
    }
    public static bool Cut(Transform victim, Transform based)
    {
        gameison = true;
        if(newcube.direction == 'z')
        {
            if (Mathf.Abs(victim.transform.position.z - based.transform.position.z) < 5)
            {
                perfect = true;
                perfectCount++;
                if (based.gameObject.name == "OriginalCube")
                    victim.transform.position = new Vector3(based.transform.position.x, based.transform.position.y + 15.05f, based.transform.position.z);
                else
                    victim.transform.position = new Vector3(based.transform.position.x, based.transform.position.y + 10.05f, based.transform.position.z);
            }
        }

        if (newcube.direction == 'x')
        {
            
            if (Mathf.Abs(victim.transform.position.x - based.transform.position.x) < 5)
            {
                perfect = true;
                perfectCount++;
                if (based.gameObject.name == "OriginalCube")
                    victim.transform.position = new Vector3(based.transform.position.x, based.transform.position.y + 15.05f, based.transform.position.z);
                else
                    victim.transform.position = new Vector3(based.transform.position.x, based.transform.position.y + 10.05f, based.transform.position.z);
            }
        }

        if (shrink == true)
        {
            if (perfect == true)
                aud = GameObject.Find("audioPerfect");
            else
            {
                aud = GameObject.Find("audio");
                perfectCount = 0;
            }
            AudioSource audio = aud.GetComponent<AudioSource>();
            audio.Play();
        
           // Debug.Log("called cut");
            Vector3 parttostay, newcubpos, fallpart;
            Color32 color = victim.gameObject.GetComponent<Renderer>().material.color;
      
            if (newcube.direction == 'x')
            {
                float tocutportion = victim.transform.position.x;
                if (tocutportion > based.position.x)
                {
                    tocutportion = tocutportion - based.position.x;
                    parttostay = new Vector3(victim.transform.localScale.x - tocutportion, 10, victim.transform.localScale.z);
                    newcubpos = new Vector3(victim.transform.position.x - tocutportion / 2, victim.transform.position.y, victim.transform.position.z);
                    fallpart = new Vector3(newcubpos.x + parttostay.x / 2 + ((based.transform.localScale.x - parttostay.x) / 2), newcubpos.y, newcubpos.z);

                }
                else
                {
                    tocutportion = based.position.x - tocutportion; 
                    parttostay = new Vector3(victim.transform.localScale.x - tocutportion, 10, victim.transform.localScale.z);
                    newcubpos = new Vector3(victim.transform.position.x + tocutportion / 2, victim.transform.position.y, victim.transform.position.z);
                    fallpart = new Vector3(newcubpos.x - parttostay.x / 2 - ((based.transform.localScale.x - parttostay.x)/ 2), newcubpos.y, newcubpos.z);

                }
                //Debug.Log(tocutportion);
                
                Destroy(victim.gameObject);

                newcub = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (perfectCount >= 2)
                    newcub.transform.localScale = parttostay + (new  Vector3(10f, 0, 10f));
                else
                    newcub.transform.localScale = parttostay;
                newcub.transform.position = newcubpos;
                cubeforce.pivot = newcubpos;
                Rigidbody rb = newcub.AddComponent<Rigidbody>() as Rigidbody;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.mass = 100000;
                rb.useGravity = false;

                newcub.GetComponent<Renderer>().material.color = color;

                //cube to fall
                if (tocutportion > 0)
                {

                    fallcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    fallcube.transform.localScale = new Vector3(based.localScale.x - parttostay.x, parttostay.y, parttostay.z);
                    fallcube.transform.position = fallpart;
                    Rigidbody frb = fallcube.AddComponent<Rigidbody>() as Rigidbody;
                    frb.mass = 100000;
                    frb.useGravity = true;
                    fallcube.GetComponent<Renderer>().material.color = color;
                }


                newcube.nextcube = newcub;
                newcube.Create = true;
                shrink = false;
            
            }
            if(newcube.direction == 'z')
            {
                float tocutportion = victim.transform.position.z;
                if (tocutportion > based.position.z)
                {
                    tocutportion = tocutportion - based.position.z;
                    parttostay = new Vector3(victim.transform.localScale.x, 10, victim.transform.localScale.z - tocutportion);
                    newcubpos = new Vector3(victim.transform.position.x, victim.transform.position.y, victim.transform.position.z - tocutportion / 2);
                    fallpart = new Vector3(newcubpos.x , newcubpos.y, newcubpos.z + parttostay.z / 2 + ((based.transform.localScale.z - parttostay.z) / 2));
                }
                else
                {
                    tocutportion = based.position.z - tocutportion;
                    parttostay = new Vector3(victim.transform.localScale.x, 10, victim.transform.localScale.z - tocutportion);
                    newcubpos = new Vector3(victim.transform.position.x, victim.transform.position.y, victim.transform.position.z + tocutportion / 2);
                    fallpart = new Vector3(newcubpos.x, newcubpos.y, newcubpos.z - parttostay.z / 2 - ((based.transform.localScale.z - parttostay.z) / 2));

                }
               // Debug.Log(tocutportion);
                Destroy(victim.gameObject);

                newcub = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (perfectCount >= 2)
                    newcub.transform.localScale = parttostay + (new Vector3(10f, 0, 10f));
                else
                    newcub.transform.localScale = parttostay;
                
                newcub.transform.position = newcubpos;
                cubeforce.pivot = newcubpos;
                Rigidbody rb = newcub.AddComponent<Rigidbody>() as Rigidbody;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.mass = 100000;
                rb.useGravity = false;
                newcub.GetComponent<Renderer>().material.color = color;

                //fallcube

                if (tocutportion > 0)
                {
                    fallcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    fallcube.transform.localScale = new Vector3(parttostay.x, parttostay.y, based.localScale.z - parttostay.z);
                    fallcube.transform.position = fallpart;
                    Rigidbody frb = fallcube.AddComponent<Rigidbody>() as Rigidbody;
                    frb.mass = 100000;
                    frb.useGravity = true;
                    fallcube.GetComponent<Renderer>().material.color = color;
                    //frb.AddForce(0, -100f, 0, ForceMode.Acceleration);
                }
                newcube.nextcube = newcub;
                newcube.Create = true;
                shrink = false;
              

            }
            
            divide d = newcub.AddComponent<divide>() as divide;
        }
        Debug.Log(perfectCount);
        return true;
    }
}
