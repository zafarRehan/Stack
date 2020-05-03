using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour {

    public Text scoreText;
    public Text gameOver, restart, area;

    private void Start()
    {
        restart.text = gameOver.text = null;
        scoreText.text = "0" ;
        
    }
    void Update () {

        scoreText.text = newcube.count.ToString();
        gameOver.text = GameOver.gameover;
        restart.text = GameOver.restart;
        area.text = dropCube.areaCube.ToString();
        
	}
}
