using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public GameObject daniel;
    public GameObject marina;
    public GameObject miguel;
    public GameObject background;

    public AudioSource sfxTransition;

    void Start()
    {
        Invoke("SFXTransition", 1.5f);
        Invoke("SFXTransition", 2.0f);
        Invoke("SFXTransition", 2.5f);
    }

    void FixedUpdate()
    {
        Invoke("Background", 0.5f);
        Invoke("Daniel", 1.5f);
        Invoke("Marina", 2.0f);
        Invoke("Miguel", 2.5f);
        Invoke("NextLevel", 9f);
    }

       
    void Daniel()
    {
        daniel.transform.position = Vector3.Lerp(daniel.transform.position, new Vector3(-3f, 0f, 0f), Time.deltaTime * 5);

    }

    void Marina()
    {
        marina.transform.position = Vector3.Lerp(marina.transform.position, new Vector3(3f, 0.2f, 0f), Time.deltaTime * 5);

    }

    void Miguel()
    {
        miguel.transform.position = Vector3.Lerp(miguel.transform.position, new Vector3(0f, 3.5f, 0f), Time.deltaTime * 5);


    }

    void Background()
    {
        background.transform.position = Vector3.Lerp(background.transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * 3);

    }

    void SFXTransition()
    {
        sfxTransition.PlayOneShot(sfxTransition.clip);

    }

    void NextLevel()
    {
        GameController.instance.NextLevel();
    }
}
