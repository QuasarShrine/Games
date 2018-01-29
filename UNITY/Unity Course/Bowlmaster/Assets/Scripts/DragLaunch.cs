using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{

    private Ball ball;

    private Vector3 mousePosStart;
    private Vector3 mousePosEnd;
    private float dragStatTime;
    private float dragEndTime;

    // Use this for initialization
    void Start() {
        ball = GetComponent<Ball>();

    }

    public void DragStart() {
        if (!ball.isBallLaunched) {
            // capture time and position on mouse click
            mousePosStart = Input.mousePosition;
            dragStatTime = Time.time;
        }
    }

    public void DragEnd() {
        if (!ball.isBallLaunched) {
            // launch the ball
            mousePosEnd = Input.mousePosition;
            dragEndTime = Time.time;
            //Debug.Log("mousePosStart : " + mousePosStart);
            //Debug.Log("dragStatTime : " + dragStatTime);
            //Debug.Log("mousePosEnd : " + mousePosEnd);
            //Debug.Log("dragEndTime : " + dragEndTime);
            //Debug.Log("================ end at "+ dragEndTime +" =================");
            //float distance = Vector3.Distance(mousePosEnd,mousePosStart);
            float timeLapse = dragEndTime - dragStatTime;
            float speedX = (mousePosEnd.x - mousePosStart.x) / timeLapse;
            float speedZ = (mousePosEnd.y - mousePosStart.y) / timeLapse;
            //float velocity = 400;
            Vector3 launchVector = new Vector3(speedX, 0, speedZ);
            ball.Launch(launchVector);
        }

    }


    public void MoveStart(float xNudge) {
        if (!ball.isBallLaunched) {
            float oldX = ball.transform.position.x;
            float oldY = ball.transform.position.y;
            float oldZ = ball.transform.position.z;
            float newX = Mathf.Clamp(oldX + xNudge, -40f, 40f);
            ball.transform.position = new Vector3(newX, oldY, oldZ);
        }
    }
}

