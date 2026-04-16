using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class OvenHandler : MonoBehaviour
{
    [SerializeField] private float _cookTime;
    [SerializeField] private Material _cookedPizzaMaterial;
    [SerializeField] private float _ovenEjectForce;
    [SerializeField] private Transform _ovenEjectPoint;
    private bool _isCooking;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (_isCooking) return; 
        
        var pizzaOrder =  collision.gameObject.GetComponent<PizzaOrder>();
        if (!pizzaOrder) return; // Not a pizza
        if (pizzaOrder.OrderDone) return;

        _isCooking = true;
        pizzaOrder.transform.position = transform.position;
        var rb = pizzaOrder.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.detectCollisions = false;
        rb.isKinematic = true;
        
        StartCoroutine(EjectPizza(pizzaOrder,  _cookTime));
    }

    private IEnumerator EjectPizza(PizzaOrder pizzaOrder, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        var rb = pizzaOrder.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        pizzaOrder.transform.position = _ovenEjectPoint.position;
        rb.AddForce(_ovenEjectForce * transform.forward, ForceMode.Impulse);
        rb.detectCollisions = true;
        _isCooking = false;
        pizzaOrder.GetComponent<MeshRenderer>().material = _cookedPizzaMaterial;
        pizzaOrder.FinishOrder();
    }
}
