using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallController : MonoBehaviour, IPointerDownHandler
{
    //[SerializeField] Collider col;
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    [SerializeField] LineRenderer aimLine;
    [SerializeField] Text strokes;
    [SerializeField] Text finalStrokes;
    //[SerializeField] Transform aimWorld;
    bool shoot;
    bool shootingMode;
    float forceFactor;
    Vector3 forceDirection;
    Ray ray;
    Plane plane;

    int shootCount;
    int pukul = 0;

    public bool ShootingMode { get => shootingMode; }
    public int ShootCount { get => shootCount; }
    public UnityEvent<int> onBallShooted = new UnityEvent<int>();
    private Vector3 lastPos;
    private void Update() 
    {
        if(shootingMode)
        {
            if(shootingMode)
            {
                lastPos = transform.position;
                if(Input.GetMouseButtonDown(0))
                {
                    aimLine.gameObject.SetActive(true);
                    plane = new Plane(Vector3.up, this.transform.position);
                }
                else if(Input.GetMouseButton(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    plane.Raycast(ray, out var distance);
                    forceDirection = (this.transform.position - ray.GetPoint(distance));
                    forceDirection.Normalize();

                    var mouseViewportPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    var ballViewportPos = Camera.main.WorldToViewportPoint(this.transform.position);
                    var pointerDirection = ballViewportPos - mouseViewportPos;
                    pointerDirection.z = 0;
                    pointerDirection.z *= Camera.main.aspect;
                    pointerDirection.z = Mathf.Clamp(pointerDirection.z, -0.5f, 0.5f);
                    forceFactor = pointerDirection.magnitude * 2;

                    var ballScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
                    var mouseScreenPos = Input.mousePosition;
                    ballScreenPos.z = 1f;
                    mouseScreenPos.z = 1f;

                    var positions = new Vector3[]{
                        Camera.main.ScreenToWorldPoint(ballScreenPos),
                        Camera.main.ScreenToWorldPoint(mouseScreenPos)};
                    aimLine.SetPositions(positions);
                    aimLine.endColor = Color.Lerp(Color.blue, Color.red, forceFactor);
                }
                else if(Input.GetMouseButtonUp(0))
                {
                    shoot = true;
                    shootingMode = false;
                    aimLine.gameObject.SetActive(false);
                    pukul++;
                    strokes.text = "" + pukul;
                    finalStrokes.text = strokes.text;
                }
            }
        }
    }
    private void FixedUpdate() 
    {
        if(shoot)
        {
            shoot = false;
            AddForce(forceDirection * force * forceFactor, ForceMode.Impulse);
            shootCount += 1;
            onBallShooted.Invoke(shootCount);
        }

        if(rb.velocity.sqrMagnitude < 0.01f && rb.velocity.sqrMagnitude != 0)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
        }
    }

    public void AddForce(Vector3 force, ForceMode forceMode = ForceMode.Impulse)
    {
        rb.useGravity = true;
        rb.AddForce(force, forceMode);
    }

    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if(this.IsMove())
        {
            return;
        }
        shootingMode = true;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.tag == "OutOfBound")
        {
            transform.position = lastPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
