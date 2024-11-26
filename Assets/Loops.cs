using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    void Start()
    {
        int number = 0;

        while(number < 5)
        {
            //do something
            Debug.Log(number);
            number++;
        }


        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(i);
            Instantiate(platform, new Vector2(Random.Range(-7f, 7f), Random.Range(-7f, 7f)), Quaternion.identity);
        }
    }

}
