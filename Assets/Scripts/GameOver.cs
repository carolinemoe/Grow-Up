using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject speech1;
    public GameObject speech2;
    private float disappearTime;
    private float appearTime = 2f;
    private bool end = false;
    private bool chatBubble = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speech1.activeSelf && (chatBubble))
        {
            speech1.SetActive(false);
         
        }
    }

    IEnumerator hey()
    {
        yield return new WaitForSeconds(2f);
        chatBubble = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (!end && col.gameObject.tag == "hit")
        {
            end = true;
            disappearTime = Time.time + appearTime;
            firstText();
        }
    }

    void firstText()
    {
        Invoke("secondText", 2f);
      //  Instantiate(speech1, new Vector3(-4.891f, -4.331f, 0), Quaternion.identity);
        speech1 = Instantiate(speech1, new Vector3(-4.891f, -4.331f, 0), Quaternion.identity);
        StartCoroutine("hey");
    }

    void secondText()
    {
        Invoke("gameEnd", 2f);
        Instantiate(speech2, new Vector3(-4.891f, -4.331f, 0), Quaternion.identity);
    }

    void gameEnd()
    {
        Debug.Log("quit");
        Application.Quit();

    }
}
