using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    GameObject heldObject;
    public Image heldDis;
    public Sprite empty;
    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        heldDis.sprite = empty;
        heldDis.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (heldObject == null)
            {
                if (collision.CompareTag("Garbage"))
                {
                    Collect(collision.gameObject);
                }
                else if (collision.CompareTag("Recycling"))
                {
                    Collect(collision.gameObject);
                }
            }
            if (collision.CompareTag("Garbage Drop Off"))
            {
                DropOff("Garbage");
            }else if(collision.CompareTag("Recycling Drop Off"))
            {
                DropOff("Recycling");
            }
        }
    }

    private void Collect(GameObject trash)
    {
        trash.GetComponent<SpriteRenderer>().enabled = false;

        heldObject = trash;

        heldDis.sprite = heldObject.GetComponent<SpriteRenderer>().sprite;
        heldDis.color = heldObject.GetComponent<SpriteRenderer>().color;

        gm.garbageOnScreen -= 1;
    }
    void DropOff(string type)
    {
        heldDis.sprite = empty;
        heldDis.color = Color.white;

        if (heldObject.CompareTag(type))
        {
            gm.score += 1;
        }
        else gm.score -= 1;

        Destroy(heldObject);
    }
}
