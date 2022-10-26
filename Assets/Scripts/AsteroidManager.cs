using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidManager : MonoBehaviour
{
    public int asteroidcount_min = 2;
    public int asteroidcount_max = 5;
    public int conteoasteroide;
    public float limitX = 10;
    public float limitY = 6;
    public GameObject asteroide;
    // Start is called before the first frame update
    void Start()
    {
        crearAsteroides();
    }

    // Update is called once per frame
    void Update()
    {
        if(conteoasteroide <= 0)
        {
            crearAsteroides();
        }
    }

    void crearAsteroides()
    {

        int asteroides = Random.Range(asteroidcount_min, asteroidcount_max);
        for (int i = 0; i < asteroides; i++)
        {
            // Debug.Log("Asteroides: " + i);
            Vector3 asteroidpos = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while (Vector3.Distance(asteroidpos, new Vector3(0,0)) < 2)
            {
                asteroidpos = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 asteroidrot = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroide, asteroidpos, Quaternion.Euler(asteroidrot));
            temp.GetComponent<AsteroidControl>().manager = this;
        }
    }

}