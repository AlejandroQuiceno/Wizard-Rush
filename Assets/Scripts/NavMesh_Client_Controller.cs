using UnityEngine;
using UnityEngine.AI;


public class NavMesh_Client_Controller : MonoBehaviour {
    [SerializeField] GameObject destination;
    [SerializeField] GameObject destination2;
    [SerializeField] NavMeshAgent client;
    [SerializeField] int limitTime;
    Transform destinationTransform;
    Transform destination2Transform;
    AudioSource[] steps = new AudioSource[2];
    givesOrder givesOrder;
    Animator clientAnimator;
    delivery clientDelivery;
    [SerializeField] bool arrival = false;//se activa cuando llego al destino
    int delivered = 0;//es cero cuando no se le ha entregado la orden y uno cuando si 
    
    public bool lose = false;//ayuda a contar las veces que no se ha entregado bien la pocion 
    
    bool cond2 = false;//sirve como condicion para que el cliente se vaya 
    void Awake() {
        destination = GameObject.Find("Destination");
        destination2 = GameObject.Find("Destination2");
        destinationTransform = destination.GetComponent<Transform>();
        destination2Transform = destination2.GetComponent<Transform>();
        clientAnimator = GetComponent<Animator>();
        steps = GetComponents<AudioSource>();
        givesOrder = FindObjectOfType<givesOrder>();
        clientDelivery = FindObjectOfType<delivery>();
    }
    public void Start() {
        if (transform.position.y <= -30) {
            for(int i =0; i < 2; i++)
            {
                steps[i].volume = 0;
            }
        } else {
            for (int i = 0; i < 2; i++)
            {
                steps[i].volume = 1;
            }
        }
    }
    void Update() {
        if (delivered == 0 && arrival == false) client.SetDestination(destinationTransform.position);
        if (Mathf.Abs(transform.position.x - destinationTransform.position.x)<=0.5f && arrival == false) {//se calcula si ya llego al primer destino si no esta a menos de medio metro no entra al condicional 
            ConditionFirst();
        }
        if (Vector3.Distance(transform.position, destinationTransform.position) <0.9) {
            cond2 = true;
        }
        if(cond2==true && clientDelivery.cond1 == true) {
            ConditionSecond();
        }
        if ((delivered==1 && arrival==true)) {//lo que pasa es que le pone un nuevo destino al cliente
          clientAnimator.SetBool("Walking", true);
          client.SetDestination(destination2Transform.position);               
        } else if (givesOrder.clientTimer >= 15f && arrival == true ) {//si el tiempo es mayor 
            LimitTime();
        }
        if (Mathf.Abs(transform.position.x - destination2Transform.position.x) <= 0.05f) {//cuando ha llegado al nuevo destino
            Destroy(gameObject);
            
        }
    }
    void ConditionFirst() {//apaga los sonidos y la animacion 
        clientAnimator.SetBool("Walking", false);
        arrival = true;
        for (int i = 0; i < 2; i++)
        {
            steps[i].volume = 0;
        }
    }
    void ConditionSecond() {//pone el delivered en uno y activa el navmesh para que se vaya a su nuevo destino
        client.enabled = true;
        delivered = 1;
    }
    void LimitTime() {//pasa cuando se termino el tiempo, pero la diferencia es que se acriva la variable lose que ayuda a contar los clientes no atendidos 
        //limitTime
        clientAnimator.SetBool("Walking", true);
        client.enabled = true;
        client.SetDestination(destination2Transform.position);
        lose = true;
    }
    public void OnTriggerEnter(Collider collision) {//se desactiva el nav cuando entra otro cliente a su collider 
        GameObject collisionedClient = collision.gameObject;
        if(collisionedClient.tag == "Client") {
            client.enabled = false;
            clientAnimator.SetBool("Walking", false);
            for (int i = 0; i < 2; i++)
            {
                steps[i].volume = 0;
            }
        }
    }
    public void OnTriggerExit(Collider collision) {//seactiva el nav cuando sale un cliente de su collider 
        GameObject collisionedClient = collision.gameObject;
        if (collisionedClient.tag == "Client") {
            client.enabled = true;
            clientAnimator.SetBool("Walking", true);
            for (int i = 0; i < 2; i++)
            {
                steps[i].volume = 1;
            }
        }
    }
}
