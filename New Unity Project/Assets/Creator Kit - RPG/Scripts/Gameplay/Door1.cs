using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGM.Gameplay
{

public class Door1 : MonoBehaviour
{

    public GameObject boulderPlate1;
    private BoulderPlate script;
    private bool isOpen = false;
    private Collider2D m_collider;
    public SpriteRenderer spriteRenderer;
    //public Sprite newSprite;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[0];

        boulderPlate1 = GameObject.Find("BoulderPlate_1");
        script = boulderPlate1.GetComponent<BoulderPlate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpen && script.isTriggered){
            isOpen = true;
            m_collider.enabled = !m_collider.enabled;
            spriteRenderer.sprite = spriteArray[1];

        } else if(isOpen && !script.isTriggered)  {
            isOpen = false;
            m_collider.enabled = !m_collider.enabled;
            spriteRenderer.sprite = spriteArray[0];
        }
    }
}
}