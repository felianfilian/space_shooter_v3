using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speed;

    private Camera mainCam;
    private Vector3 offset;

    // restrictions
    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;

    void Start()
    {
        mainCam = Camera.main;
        speed = 8;

        StartCoroutine(SetBoundries());
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveDirection = moveAction.action.ReadValue<Vector2>();
        //transform.Translate(moveDirection * speed * Time.deltaTime);

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);

        if (Touch.activeTouches.Count > 0)
        {
            if (Touch.activeTouches[0].finger.index == 0)
            {
                Touch myTouch = Touch.activeTouches[0];


                Vector3 touchPos = myTouch.screenPosition;
                touchPos = mainCam.ScreenToWorldPoint(touchPos);

                if (Touch.activeTouches[0].phase == TouchPhase.Began)
                {
                    offset = touchPos - transform.position;
                }
                if (Touch.activeTouches[0].phase == TouchPhase.Moved || Touch.activeTouches[0].phase == TouchPhase.Stationary)
                {
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
                }
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundries()
    {
        yield return new WaitForEndOfFrame();

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.08f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.92f)).y;
    }
}
