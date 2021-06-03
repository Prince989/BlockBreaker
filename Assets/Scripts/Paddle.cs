using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


    public FloatingJoystick joy;
    public bool autoPlay = false;
    public float handleSpeedReduce = 15;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            Autoplay();
        }
    }

    void Autoplay()
    {
        Vector3 mousePosInBlocks = ball.transform.position;
        Vector3 paddlePos = new Vector3(1.95f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks.x, 1f, 16f);
        transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        //float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
        /*        float PosInBlocks = (joy.Direction.x );
                Vector3 paddlePos = new Vector3(1.95f, this.transform.position.y, 0f);
                paddlePos.x = Mathf.Clamp(PosInBlocks,-0.63f, 16f);
                transform.position = paddlePos;*/
        float zarib = joy.Direction.x / handleSpeedReduce;
        if((transform.position.x + zarib) > 0.82f && (transform.position.x + zarib) < 16f)
        transform.position = new Vector3(transform.position.x + zarib,transform.position.y,transform.position.z);
    }
}
