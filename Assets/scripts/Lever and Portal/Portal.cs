using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameManager gameManager;
    public Canvas interactCanvas;

    private bool active;
    private SpriteRenderer spriteRenderer;
    public Sprite activatedPortal;

    public GameObject playerToDelete;
    private bool triggered;

    [Header("Animation effect")]
    public GameObject animator;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        active=false;
        interactCanvas.enabled=false;
    }

    void Update()
    {
        playerInput();
    }

    void playerInput(){
        if(Input.GetKeyDown(KeyCode.E)&&triggered){
            Debug.Log("one portal activated");
            gameManager.IncrementState();
            playerToDelete.SetActive(false);
            GameObject temp = Instantiate(animator, transform.position, Quaternion.identity, transform);
            temp.SetActive(true);
            Destroy(temp, 0.5f);
        }
    }

    public void setActive(){
        active = true;
        spriteRenderer.sprite = activatedPortal;
        GameObject temp = Instantiate(animator, transform.position, Quaternion.identity, transform);
        temp.SetActive(true);
        Destroy(temp, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && active){
            triggered=true;
            interactCanvas.enabled=true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interactCanvas.enabled=false;
        triggered=false;
    }
}
