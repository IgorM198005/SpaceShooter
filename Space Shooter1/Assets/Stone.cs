using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;

        float hfWidth = spriteRenderer.sprite.bounds.size.x / 2;

        this.rb = GetComponent<Rigidbody2D>();

        Vector2 vpWdTopLeft = Camera.main.ViewportToWorldPoint(Vector2.zero);

        vpWdTopLeft.x += hfWidth;

        Vector2 vpWdBottomRight = Camera.main.ViewportToWorldPoint(new Vector2(Camera.main.rect.width, Camera.main.rect.height));

        vpWdBottomRight.x -= hfWidth;

        Vector2 vpWdSize = vpWdBottomRight - vpWdTopLeft;

        this.bzPt0 = vpWdBottomRight - Vector2.right * Random.Range(0f, 1f) * vpWdSize.x;

        Vector2 vpWdSizeHfx = Vector2.Scale(vpWdSize, Vector2.right * 0.5f + Vector2.up);

        var bzPt1n = this.GetBzPt1();

        this.bzPt1 = bzPt0 - Vector2.Scale(bzPt1n, vpWdSizeHfx);

        this.bzPt2 =  bzPt0 - Vector2.up * vpWdSizeHfx.y;       
        
        if (this.bzPt1.x != bzPt0.x)
        {
            float et = default(float);

            if (this.TryGetBezierExtremum(out et))
            {
                Vector2 ep = this.GetBzPoint(et);

                if ((ep.x < vpWdTopLeft.x) || (ep.x > vpWdBottomRight.x))

                    this.bzPt1.x = 2f * this.bzPt0.x - this.bzPt1.x;                
            }
        }

        transform.position = this.bzPt0;

        this.lifesicle = this.tb * Stone.GetLengthRatio(bzPt1n.x) / this.Velocity;
    }

    private float ts;

    private float lifesicle;

    private float tb = 5f;

    private Rigidbody2D rb;

    public float Velocity;

    // Update is called once per frame
    void Update () {

        ts += Time.deltaTime;

        float t = ts / lifesicle;

        if (t > 1f)

            Object.Destroy(this.gameObject);

        else

            rb.MovePosition(this.GetBzPoint(t));		
	}

    private Vector2 bzPt0;

    private Vector2 bzPt1;

    private Vector2 bzPt2;

    private Vector2 GetBzPt1() {
        
        return new Vector2(Random.Range(-1f, 1f), Random.Range(0.15f, 0.85f));
    }    

    private Vector2 GetBzPoint(float t)
    {
        float flt = 1f - t;

        return flt * flt * this.bzPt0 + 2f * t * flt * this.bzPt1 + t * t * this.bzPt2;
    }

    private static float GetLengthRatio(float x)
    {
        return Stone.tbs[System.Convert.ToInt32(Mathf.Round(Mathf.Abs(x))) * 10];
    }

    private static float[] tbs = new float[] { 0.6762057f, 0.6806517f, 0.6937925f, 0.7147893f, 0.7425881f, 0.7761002f, 0.8143376f, 0.8564632f, 0.9017987f, 0.9497911f, 1 };

    private void OnBecameInvisible()
    {
        Object.Destroy(this.gameObject);
    }

    private bool TryGetBezierExtremum(out float t)
    {
        float a = this.bzPt0.x + this.bzPt2.x - 2.0f * this.bzPt1.x;

        if (a == 0f)
        {
            t = default(float);

            return false;
        }

        t = (this.bzPt0.x - this.bzPt1.x) / a;

        return true;
    }

    public GameObject Explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var name = collision.gameObject.name;

        if ((name == "stone(Clone)") || (name == "stone 1(Clone)") || (name == "stone 2(Clone)"))
        {
            Instantiate(this.Explosion, transform.position, transform.rotation);

            Object.Destroy(this.gameObject);

            Object.Destroy(collision.gameObject);
        }

    }
}

