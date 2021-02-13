using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehavior : MonoBehaviour
{
    [SerializeField]
    private float fireRadius = 2.0f;

    [SerializeField]
    private float leakageFraction = 0.018f;

    [SerializeField]
    private float chargeIncrement = 2f;

    [SerializeField]
    private float inducedChargeFraction = 0.1f;

    [SerializeField]
    private float threshold = 100.0f;

    [SerializeField]
    private float maxScale = 1.0f;

    [SerializeField]
    private float speed = 1.0f;

    private float charge = 0.0f;
    private float leakage = 0.0f;
    private Collider[] closestCells;
    Renderer rend;

    private void Start() {
        closestCells = Physics.OverlapSphere(transform.position, fireRadius);
        rend = GetComponent<Renderer>();
        charge = Random.Range(0.0f, threshold);
    }

    private void FixedUpdate() {
        if (charge >= threshold) {
            InduceChargeToClosestCells();
            charge = 0.0f;
            leakage = 0.0f;
        }

        charge += chargeIncrement * speed;
        leakage = leakageFraction * charge * speed;
        charge -= leakage;

        float scale = maxScale * charge / threshold;
        transform.localScale = Vector3.one * scale;

        rend.material.SetFloat("_Charge", charge);
    }

    private void InduceChargeToClosestCells() {
        foreach (Collider cell in closestCells)
        {    
            cell.GetComponent<CellBehavior>().ReceiveCharge(charge * inducedChargeFraction);
        }
    }

    public void ReceiveCharge(float inducedCharge) {
        charge += inducedCharge;
    }
}
