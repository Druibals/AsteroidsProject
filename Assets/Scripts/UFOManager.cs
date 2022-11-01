using UnityEngine;

public class UFOManager : MonoBehaviour
{
    public GameObject ufo;
    public float speed = 10;
    public int conteoufo;
    public float limitX = 7;
    public float limitY = 3;
    public float spawnrate = 60.0f;
    public float nextspawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.puntuacion >= 1000 && conteoufo <= 0 && Time.time > nextspawn)
        {
            crearufo();
            nextspawn = Time.time+spawnrate;
        }
    }

    void crearufo()
    {
        Vector3 ufopos = new Vector3(Random.Range(limitX, -limitX), Random.Range(limitY, -limitY));
        while (Vector3.Distance(ufopos, new Vector3(0, 0)) < 2)
        {
            ufopos = new Vector3(Random.Range(limitX, -limitX), Random.Range(limitY, -limitY));
        }
        // Vector3 uforot = new Vector3(0, 0, Random.Range(0f, 360f));
        GameObject temp = Instantiate(ufo, ufopos, Quaternion.identity);
        temp.GetComponent<UFOControl>().manager = this;
        conteoufo += 1;

    }
}
