using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WeaponBob : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController characterController;

    [Header("Bob Settings")]
    [SerializeField] private float bobspeed = 8f;
    [SerializeField] private float bobAmount = 0.3f;

    private Vector3 startPosition;
    private float timer;
    void Awake()
    {
        startPosition = transform.localPosition;
    }
    void Update()
    {
        if(characterController.velocity.magnitude > 0.1 && characterController.isGrounded)
        {
            WeaponBobMech();
        }
        else
        {
            timer = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime * 10f);
        }
    }

    private void WeaponBobMech()
    {
        float speed = characterController.velocity.magnitude;
        timer += Time.deltaTime * bobspeed * speed;
        float x = Mathf.Cos(timer) * bobAmount;
        float y = Mathf.Abs(Mathf.Sin(timer)) * bobAmount;

        transform.localPosition = startPosition + new Vector3(x,y,0);
    }
}
