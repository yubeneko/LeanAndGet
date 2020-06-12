using UnityEngine;

public class Crystal : MonoBehaviour
{
    AudioSource audioSource;
    void Start ()
    {
        audioSource = GetComponent<AudioSource> ();
        transform.rotation = Quaternion.Euler (-90f, 0f, Random.Range (-180f, 180f));
    }

    void Update ()
    {
        transform.Rotate (0f, 0f, 1f);
    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot (audioSource.clip);
            GetComponent<MeshRenderer> ().enabled = false;
            GetComponent<Collider> ().enabled = false;
            GetComponentInChildren<Light> ().enabled = false;
            GameObject.FindWithTag ("uiText").GetComponent<UIScore> ().CountUp ();
            Destroy (this.gameObject, 3f);
        }
    }
}