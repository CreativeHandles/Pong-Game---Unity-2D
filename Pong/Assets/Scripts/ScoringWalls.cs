using UnityEngine;

public class ScoringWalls : MonoBehaviour {


	// Update is called once per frame
	public void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball")
        {
            GameManager.Score(this.gameObject);
            hitInfo.gameObject.SendMessage("ResetBall");

            FindObjectOfType<AudioManager>().Play("score");
        }
	}
}
