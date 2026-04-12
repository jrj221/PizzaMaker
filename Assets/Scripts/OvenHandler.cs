using System;
using System.Collections;
using UnityEngine;

public class OvenHandler : MonoBehaviour
{
    [SerializeField] private float _cookTime;
    [SerializeField] private float _ovenEjectForce;
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
        rb.AddForce(10f * _ovenEjectForce * transform.right);
        rb.detectCollisions = true;
        _isCooking = false;
        pizzaOrder.FinishOrder();
    }
}
