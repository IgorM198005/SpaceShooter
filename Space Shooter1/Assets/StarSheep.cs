using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSheep : MonoBehaviour {

    public float speed = 24f;

    private float hfWidth;

    public GameObject StoneBullet;

    private float hfHeight;

    private float strobLeft;

    private float strobRight;

    // Use this for initialization
    void Start() {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;

        hfWidth = spriteRenderer.sprite.bounds.size.x / 2f;

        hfHeight = spriteRenderer.sprite.bounds.size.y / 2f;

        Vector2 vpWdTopLeft = Camera.main.ViewportToWorldPoint(Vector2.zero);

        this.strobLeft = vpWdTopLeft.x + hfWidth;

        Vector2 vpWdBottomRight = Camera.main.ViewportToWorldPoint(new Vector2(Camera.main.rect.width, Camera.main.rect.height));

        this.strobRight = vpWdBottomRight.x - hfWidth;

        this.rb = GetComponent<Rigidbody2D>();
    }

    private Rigidbody2D rb;

    public float FireDelay = 0.16f;

    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;

        float fc = Input.GetAxis("Horizontal");

        if (fc != 0f)
        {
            var np = transform.position + fc * Vector3.right * speed * Time.deltaTime;

            if (np.x < this.strobLeft)

                np.x = this.strobLeft;

            else if (np.x > this.strobRight)

                np.x = this.strobRight;

            rb.MovePosition(np);
        }

        if (this.nextFire > 0f) this.nextFire -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (this.nextFire <= 0f)
            {
                Vector3 bulletPosition = transform.position + new Vector3(0f, hfHeight);

                Instantiate(this.StoneBullet, bulletPosition, Quaternion.identity);

                this.nextFire = this.FireDelay;
            }
        }
    }



    public GameObject Explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(this.Explosion, transform.position, transform.rotation);
        
        GameObject.Find("asteroidGenerator").GetComponent<AsteroidGenerator>().EndScene();

        Object.Destroy(collision.gameObject);

        Object.Destroy(this.gameObject);
    }    
}
