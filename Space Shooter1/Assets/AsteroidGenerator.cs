using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidGenerator : MonoBehaviour {

    public float Frequency;

    public float Velocity;

    private float delay;

    private float span;

    public GameObject Asteroid0;

    public GameObject Asteroid1;

    public GameObject Asteroid2;

    public GameObject Asteroid3;

    // Use this for initialization
    void Start () {

        this.span = this.Velocity;

        this.AddAsteroid();
		
	}
	
	// Update is called once per frame
	void Update () {

        this.TryIncreaseFrequncy();

        this.AddAsteroid();

    }

    private void AddAsteroid()
    {
        this.delay -= Time.deltaTime;

        if (this.delay <= 0f)
        {
            int type = Random.Range(0, 4);

            GameObject ater = null;

            switch(type)
            {
                case 0:

                    ater = this.Asteroid0;

                    break;

                case 1:

                    ater = this.Asteroid1;

                    break;
                case 2:

                    ater = this.Asteroid2;

                    break;
                case 3:

                    ater = this.Asteroid3;

                    break;
            }


            GameObject go = (GameObject)Instantiate(ater, Vector2.zero, Quaternion.identity);

            var stone = go.GetComponent<Stone>();

            stone.Velocity = this.astVelocity;

            this.delay = 1f / this.Frequency;

            Debug.Log(this.delay);

        }
    }

    private float astVelocity = 1f;

    private void TryIncreaseFrequncy()
    {
        this.span -= Time.deltaTime;

        if (this.span <= 0f)
        {
            this.Frequency *= 2f;

            this.span = this.Velocity;

            astVelocity *= 2f;
        }
    }    


    public void EndScene()
    {        
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1.3f);

        SceneManager.LoadScene(0);
    }
}
