using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePlace : MonoBehaviour
{
    public Sprite right;
    public Sprite notRight;
    SpriteRenderer spriteRenderer;
    Sprite defaultSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag+"Place" == gameObject.tag)
        {
            spriteRenderer.sprite = right;
        }
        else if((other.gameObject.tag + "Place" != gameObject.tag) && 
            !other.gameObject.CompareTag("Wall") && !other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.sprite = notRight;
        }
        StartCoroutine(MakeDefaultSprite());
    }


    IEnumerator MakeDefaultSprite()
    {
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = defaultSprite;
    }
   
}
