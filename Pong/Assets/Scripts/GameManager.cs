using UnityEngine;

public class GameManager : MonoBehaviour {

    static int playerScore = 0;
    static int opponentScore = 0;

    //GUISkin gameSkin;

    Transform gameBall;

    // stores the ball as a variable (tagged to Ball)
    void Start()
    {
        gameBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    public static void Score(GameObject wall) {
		if (wall.name == "rightWall")
        {
            playerScore++;
        }
        else
        {
            opponentScore++;
        }
    }

    // create UI for the game
    public void OnGUI()
    {
        //GUI.skin = gameSkin;
        GUI.Label(new Rect(Screen.width / 2-150-18, 20, 100, 100), "" + playerScore);
        GUI.Label(new Rect(Screen.width / 2+150+18, 20, 100, 100), "" + opponentScore);

        // functionality for resetting game
        if (GUI.Button(new Rect(Screen.width / 2-50, 15, 100, 40), "RESET"))
        {
            playerScore = 0;
            opponentScore = 0;

            gameBall.gameObject.SendMessage("ResetBall");
        }
    }
}
