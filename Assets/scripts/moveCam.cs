using UnityEngine;

public class moveCam : MonoBehaviour
{

    public static bool camdown;
    private void Start()
    {
        camdown = false;
        dropCube.destPosition = transform.position;
    }
    void Update()
    {
        if (transform.position.y < dropCube.destPosition.y)
        {
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
        }

        if (GameOver.isOver == true && camdown == false)
        {
            if (transform.position.y > (110 + newcube.count * 5))
            {
                transform.position = transform.position + new Vector3(0f, 5f, 0f);


            }
            else
            {
                camdown = true;
            }
        }
    }
}