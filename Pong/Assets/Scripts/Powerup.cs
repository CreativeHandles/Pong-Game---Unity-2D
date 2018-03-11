using UnityEngine;

public class Powerup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
