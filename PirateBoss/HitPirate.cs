using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPirate : MonoBehaviour
{
    public GameObject[] teleportPoints;
    public GameObject teleportEffect;
    public GameObject prefabSword;
    private BoxCollider2D boxHitPirate;

    private Animator animPirate;
    public GameObject pirate;
    public AudioSource pirateHit;
    public AudioSource teleportIn;
    public AudioSource teleportOut;
    public AudioSource dieScream;

    private int life = 1;
    public int totallife;
    public static bool activeSword = false;
    public static bool destroySword = false;

    void Start()
    {
        totallife = life;
        animPirate = pirate.GetComponent<Animator>();
        boxHitPirate = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        DiePirate();
    }

    void Teleport()
    {
        int destiny = Random.Range(0, teleportPoints.Length);
        if (teleportPoints[destiny])
        {
            pirate.transform.position = teleportPoints[destiny].transform.position;

        }
        pirate.gameObject.SetActive(true);
        teleportOut.PlayOneShot(teleportOut.clip);
        teleportEffect.transform.position = new Vector3(pirate.transform.position.x, pirate.transform.position.y, pirate.transform.position.z);
        teleportEffect.GetComponent<ParticleSystem>().Stop();
        boxHitPirate.isTrigger = false;
        activeSword = true;
        Instantiate(prefabSword, pirate.transform.position, pirate.transform.rotation);

    }

    void TeleportInSFX()
    {
        teleportIn.PlayOneShot(teleportIn.clip);
    }

    void DiePirate()
    {
        if (totallife <= 0)
        {
            Destroy(pirate.gameObject);
            GameController.instance.trophySummon.SetActive(true);
        }
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animPirate.SetBool("Hit", true);
            pirateHit.PlayOneShot(pirateHit.clip);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            life -= 1;
            totallife = life;
            destroySword = true;
            boxHitPirate.isTrigger = true;
            teleportEffect.GetComponent<ParticleSystem>().Play();
            Invoke("Teleport", 2f);
            Invoke("TeleportInSFX", 1.0f);

        }
    }

    

}
