using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start ()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update ()
    {
        var newPos = new Vector3 (10f, player.transform.position.y, 0f);
        transform.position = newPos;
    }
}