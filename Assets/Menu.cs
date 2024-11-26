using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(gameObject.tag == "StartGame")
            {
                StartCoroutine(Start(0.4f));

            }

            if (gameObject.tag.Equals("EndGame")) 
            {
                Application.Quit();

            }

        }
      
    }

    public IEnumerator Start(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }
}
