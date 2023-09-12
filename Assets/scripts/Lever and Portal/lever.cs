using UnityEngine;

public class lever : MonoBehaviour
{
    [SerializeField] private GameObject Portal;

    public Canvas interactCanvas;

    [Header ("Sprite stuff")]
    private SpriteRenderer spriteRenderer;
    public Sprite leverUp;

    [Header("Audio")]
    public AudioSource audioSource;

    private Portal portalScript;
    private bool triggered;
    private bool leverstate;

    void Start()
    {
        portalScript = Portal.GetComponent<Portal>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        interactCanvas.enabled=false;
        triggered=false;
        leverstate=false;
    }

    void Update()
    {
        playerInput();
    }

    void playerInput(){
        if(Input.GetKeyDown(KeyCode.E) && triggered && !leverstate){
            portalScript.setActive();
            spriteRenderer.sprite = leverUp;
            leverstate=true;
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {

        if(collisionInfo.CompareTag("Player") && !leverstate){
            triggered=true;            
            interactCanvas.enabled=true;


        }
    }

    void OnTriggerExit2D(Collider2D other){
        interactCanvas.enabled=false;
        triggered=false;
    }
}
