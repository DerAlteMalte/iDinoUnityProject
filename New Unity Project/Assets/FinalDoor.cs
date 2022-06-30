using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGM.Gameplay
{

public class FinalDoor : MonoBehaviour
{

    public GameObject ah1;
    private ArtifactHolder script1;
    public GameObject ah2;
    private ArtifactHolder script2;
    public GameObject ah3;
    private ArtifactHolder script3;
    public GameObject ah4;
    private ArtifactHolder script4;
    //private bool isOpen = false;
    private Collider2D m_collider;
    public SpriteRenderer spriteRenderer;
    //public Sprite newSprite;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        //todo
        m_collider = GetComponent<Collider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[0];

        ah1 = GameObject.Find("ArtifactHolder1");
        script1 = ah1.GetComponent<ArtifactHolder>();
        ah2 = GameObject.Find("ArtifactHolder2");
        script2 = ah2.GetComponent<ArtifactHolder>();
        ah3 = GameObject.Find("ArtifactHolder3");
        script3 = ah3.GetComponent<ArtifactHolder>();
        ah4 = GameObject.Find("ArtifactHolder4");
        script4 = ah4.GetComponent<ArtifactHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script1.isTriggered && script2.isTriggered && script3.isTriggered && script4.isTriggered){
            Destroy(this.gameObject);
            /*
            m_collider.enabled = !m_collider.enabled;
            spriteRenderer.sprite = spriteArray[1];
            */
        }
    }
}
}