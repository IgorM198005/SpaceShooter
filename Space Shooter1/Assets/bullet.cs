using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float Speed = 9f;

    // Use this for initialization
    void Start()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;

        transform.position = transform.position + new Vector3(0, 1.1f * spriteRenderer.sprite.bounds.size.y);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.Speed);

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.Speed);
    }

    private void OnBecameInvisible()
    {
        Object.Destroy(this.gameObject);
    }

    public GameObject Explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("asteroidGenerator").GetComponent<tMenu>().Score++;

        Instantiate(this.Explosion, transform.position, transform.rotation);

        Object.Destroy(collision.gameObject);

        Object.Destroy(this.gameObject);
    }
}