using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;


public class BirdScript : MonoBehaviour
{
    //ClientC client = new ClientC();
    //float speed = 100.0f;
    //public string host = "localhost";
    //public int port = 5000;
    //public float pointx = 0f;
    //public float pointy = 0f;
    //bool connected = false;
    //public static string[] movepoints = new string[0];

    private bool isMoving = false;
    private bool Cooldown = false;
    private int Cooldown_Counter = 0;
    private int dustct = 0;
    public LogicMangerScript mangerScript;
    public Vector3 targetPosition;
    public Rigidbody2D bird;
    public ParticleSystem dust;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        mangerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMangerScript>();
        //ConnectToSocketAsync();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        mangerScript.gameover();
        isAlive = false; // Set isAlive to false when collision occurs
        isMoving = false; // Stop the movement
    }

     void Update()
    {
        if (/*connected*/ !isMoving && isAlive)
        {
            /*await client.ReceiveMessageAsync();
            if (ClientC.Movepoints.Length != 0)
            {
                double.TryParse(ClientC.Movepoints[0], out double x);
                double.TryParse(ClientC.Movepoints[1], out double y);

                float rescaledX = (float)((x / 800) * 1280);
                float rescaledY = (float)((y / 640) * 720);

                Vector3 newTargetPosition = new Vector3(rescaledX, -rescaledY, 0.0f);

                StartCoroutine(MoveTowardsTarget(newTargetPosition));
            }
            */        
            Cooldown_Counter++;
            if ( Cooldown_Counter >= 10000 )
            {
                Cooldown_Counter = 0;
                dust.Stop();
                Cooldown= false;
            }
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                bird.velocity = Vector2.up * 200;    
            }
            if (Input.GetKeyDown(KeyCode.F) == true && Cooldown==false)
            {
                bird.velocity = Vector2.right * 500;
                dust.Play();
                Cooldown = true;
            }
            if (bird.transform.position.y <= -570 )
            {
                bird.transform.position = new Vector3(bird.transform.position.x,-570,bird.transform.position.z);
            }
            if (bird.transform.position.y >= 55)
            {
                bird.transform.position = new Vector3(bird.transform.position.x, 55, bird.transform.position.z);
            }
        }
    }
    /*async void ConnectToSocketAsync()
    {
        connected = await client.ConnectToSocketAsync(host, port);
    }
    */
    /*
    IEnumerator MoveTowardsTarget(Vector3 newTargetPosition)
    {
        if (bird == null) yield break;

        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.0009f && isAlive)
        {
            if (bird == null) yield break;

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                Time.fixedDeltaTime * speed
            );

            yield return null;
        }

        if (bird == null) yield break;

        targetPosition = newTargetPosition;
        isMoving = false;
    }

    void FixedUpdate()
    {
        if (bird == null || !isAlive) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            Time.smoothDeltaTime * speed
        );
    }
*/
}

/*
public class ClientC
{
    private static string[] movepoints = new string[0];
    public static string[] Movepoints { get { return movepoints; } }

    private NetworkStream stream;
    private TcpClient tcpClient;

    public async Task<bool> ConnectToSocketAsync(string host, int portNumber)
    {
        try
        {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(host, portNumber);
            stream = tcpClient.GetStream();
            Debug.Log("Connection Made! with " + host);
            return true;
        }
        catch (System.Net.Sockets.SocketException e)
        {
            Debug.Log("Connection Failed: " + e);
            return false;
        }
    }

    public async Task ReceiveMessageAsync()
    {
        try
        {
            if (tcpClient == null || !tcpClient.Connected)
                return;

            byte[] receiveBuffer = new byte[8 * 1024];
            int bytesReceived = await stream.ReadAsync(receiveBuffer, 0, receiveBuffer.Length);

            if (bytesReceived > 0)
            {
                string data = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
                string[] points = data.Split(',');
                movepoints = points;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Connection not initialized : " + e);
        }
    }

    public void CloseConnection()
    {
        if (tcpClient != null && tcpClient.Connected)
        {
            stream.Close();
            tcpClient.Close();
            Debug.Log("Connection terminated");
        }
    }
}
*/