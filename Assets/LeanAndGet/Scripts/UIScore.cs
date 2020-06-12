using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    Text text;
    int score;

    void Start ()
    {
        text = GetComponent<Text> ();
        text.text = "Score: " + score.ToString ();
    }

    public void CountUp ()
    {
        score++;
        text.text = "Score: " + score.ToString ();
    }
}