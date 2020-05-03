using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{
    public static bool isOver;
    public GameObject orig;
    public static string restart, gameover;


    private void Start()
    {
        isOver = false;
    }

    private void Update()
    {
        StartCoroutine(delay(0.2f));
    }


    public IEnumerator delay(float time)
    {
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(time);

        if (dropCube.dropped == true && CubeCut.gameison == false)
        {
            isOver = true;
            dropCube.destPosition = new Vector3(0, 0, 0);
            moveCam.camdown = false;
            //moveCam.bringcamdown();

            gameover = "GAME OVER";
            restart = "TAP TO RESTART";
            if(Input.GetKeyDown("down") || Input.touchCount>0)
            {
                if (Input.touchCount > 0)
                {

                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Ended)
                    {

                        gameover = restart = null;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
                else
                {
                    gameover = restart = null;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
            
    }
}
