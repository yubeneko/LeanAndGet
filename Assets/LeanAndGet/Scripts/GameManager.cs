using UnityEngine;
using UnityEngine.UI;
using ZigSimTools;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text guideLabel;
    AudioSource audioSource;

    void Start ()
    {
        var playerRb = player.GetComponent<Rigidbody> ();
        playerRb.constraints = RigidbodyConstraints.FreezePosition;
        guideLabel.text = "Tap your smart phone to Start";
        audioSource = GetComponent<AudioSource> ();

        ZigSimDataManager.Instance.StartReceiving ();
        ZigSimDataManager.Instance.TouchCallBack += (ZigSimTools.Touch[] touches) =>
        {
            if (touches.Length >= 1)
            {
                playerRb.constraints = RigidbodyConstraints.None;
                guideLabel.text = "";
                audioSource.PlayOneShot (audioSource.clip);
            }
        };
    }

    public void GameEnd ()
    {
        audioSource.PlayOneShot (audioSource.clip);
        guideLabel.text = "Finish!";
    }
}