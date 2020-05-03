using UnityEngine;

public class newcube : MonoBehaviour
{

    public static GameObject[] cube;
    public static int count;
    public static GameObject nextcube, origcol;
    public static bool Create;
    public static char direction;
    public Transform original;

    void Start()
    {
        //GameObject cam = GameObject.Find("Main Camera");
        //cam.GetComponent<Camera>().backgroundColor = new Color32((byte)Random.Range(150, 256), (byte)Random.Range(150, 256), (byte)Random.Range(150, 256), 200);
        count = 0;
        Physics.gravity = new Vector3(0, -98f, 0);
        cube = new GameObject[1000];
        origcol = GameObject.Find("OriginalCube");
        origcol.GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 200);
        Create = true;

        cube[count] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube[count].transform.position = new Vector3(-130f, original.transform.position.y + 15.05f, original.transform.position.z); cube[count].transform.localScale = new Vector3(original.transform.localScale.x, original.transform.localScale.y - 1, original.transform.localScale.z);
        cube[count].transform.localScale = new Vector3(100, 10, 100);
        Rigidbody rb = cube[count].AddComponent<Rigidbody>() as Rigidbody;
        cubeforce f = cube[count].AddComponent<cubeforce>() as cubeforce;
        dropCube dr = cube[count].AddComponent<dropCube>() as dropCube;
        //cube[count].GetComponent<Renderer>().material = original.gameObject.GetComponent<Renderer>().material;
        cube[count].GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 200);

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        rb.drag = 0.6f;
        rb.mass = 1000;
        direction = 'x';
        nextcube = cube[count];
        dropCube.dropped = false;
        Create = false;
        CubeCut.gameison = false;

    }


    void FixedUpdate()
    {
        if (Create == true)
        {
            
            cube[count] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (direction == 'x')
                cube[count].transform.position = new Vector3(nextcube.transform.position.x, nextcube.transform.position.y + 10.05f, 130f);
            if (direction == 'z')
                cube[count].transform.position = new Vector3(-130f, nextcube.transform.position.y + 10.05f, nextcube.transform.position.z);
            cube[count].transform.localScale = nextcube.transform.localScale;
            //cube[count].GetComponent<Renderer>().material = nextcube.gameObject.GetComponent<Renderer>().material;

            Rigidbody rb = cube[count].AddComponent<Rigidbody>() as Rigidbody;
            cubeforce f = cube[count].AddComponent<cubeforce>() as cubeforce;
            dropCube dr = cube[count].AddComponent<dropCube>() as dropCube;
            rb.mass = 1000;


            //Debug.Log(nextcube.GetComponent<Renderer>().material);
            //cube[count].GetComponent<Renderer>().material = nextcube.gameObject.GetComponent<Renderer>().material;
            cube[count].GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 200);
            


            rb.constraints = RigidbodyConstraints.FreezeRotation;
            if (direction == 'x')
            {
                direction = 'z';
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            }
            else
            {
                direction = 'x';
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            rb.useGravity = false;
            nextcube = cube[count];

            dropCube.dropped = false;
            Create = false;
            CubeCut.gameison = CubeCut.perfect = false;

        }
    }
}
