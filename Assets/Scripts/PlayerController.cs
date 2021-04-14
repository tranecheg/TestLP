using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private bool onPosition;
    public GameSettings gameSettings;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = gameSettings.playerSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<PlayerShooting>().enabled==false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        if (agent.velocity.magnitude > 0)
           anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);


        if (GameObject.Find("Enemy")!=null && GameObject.Find("Enemy").transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().isVisible && onPosition)
            OnPosition();
        else
            OffPosition();

    }

    void OnPosition()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<PlayerShooting>().enabled = true;
    }
    void OffPosition()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<PlayerShooting>().enabled = false;
       
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OnPosition")
            onPosition = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "OnPosition")
            onPosition = false;
    }

}
