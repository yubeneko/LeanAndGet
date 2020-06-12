using UnityEngine;

public class BigCrystal : MonoBehaviour
{
    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject.FindWithTag ("GameController")
                .GetComponent<GameManager> ().GameEnd ();
        }
    }
}