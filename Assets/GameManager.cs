using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public int deathCount;

    public TMP_Text text;
    public TMP_Text text2;

    public bool deathTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score.ToString();
        //text2.text = "Deaths: " + deathCount.ToString();

        if (deathTime == true)
        {
            StartCoroutine(Death(0.4f));

        }

        if(score >= 20)
        {
           SceneManager.LoadScene(2);

        }
    }

    public IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
