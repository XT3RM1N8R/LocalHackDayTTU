using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{

    Transform SnakeTransform;           //Transform  -> Position Control
    float lastmove;                     //Time control
    float TimeInBetweenMoves = 0.25f;   //Time control
    Vector3 direction;                  //Postion -> Direction

    int[,] location = new int[10,10];
    int SnakeScore = 5;
    int snakeX = 0;
    int snakeY = 4;

    bool lost;


    public GameObject Token;

    private void Start()
    {
        SnakeTransform = GetComponent<Transform>();
        direction = Vector3.right;

        location[snakeX, snakeY] = SnakeScore;

        location[8, 4] = -1;

        
        GameObject go = Instantiate(Token) as GameObject;
        go.transform.position = new Vector3(8, 4, 0);
        go.name = "Token";
    }


	private void Update()
    {
        if (lost)
        {
            return;
        }



        if(Time.time - lastmove > TimeInBetweenMoves)
        {


            //Reset Tiles that are 1
            for(int i = 0; i < location.GetLength(0); i++)
            {
                for (int j = 0; j < location.GetLength(1); j++)
                {
                    if(location[i,j] > 0)
                    {
                        location[i, j]--;
                        if(location[i,j] == 0)
                        {
                            //destroy something
                            GameObject tail = GameObject.Find(i.ToString() + j.ToString());
                            if (tail != null)
                            {
                                Destroy(tail);
                            }
                            
                        }
                    }
                }
            }

            lastmove = Time.time;

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(snakeX, snakeY, 0);
            go.name = snakeX.ToString() + snakeY.ToString();

            //Limits

            if(direction.x == 1)
            {
                snakeX++;
            }
            if (direction.x == -1)
            {
                snakeX--;
            }
            if (direction.y == 1)
            {
                snakeY++;
            }
            if (direction.y == -1)
            {
                snakeY--;
            }

            if (snakeX > 9 || snakeX < 0 || snakeY > 9 || snakeY < 0)
            {
                lost = true;
                Debug.Log("You Lost");
                
            }
            else
            {
                //we eat an apple
                if (location[snakeX, snakeY] == -1)
                {

                    GameObject DestroyToken = GameObject.Find("Token");
                    Destroy(DestroyToken);
                    SnakeScore++;
                    
                    for (int i = 0; i < location.GetLength(0); i++)
                    {
                        for (int j = 0; j < location.GetLength(1); j++)
                        {
                            if(location[i,j] > 0)
                            {
                                location[i, j]++;
                            }

                        }

                    }
                    //Create Apple

                    int TokenX = UnityEngine.Random.Range(0, location.GetLength(0));
                    int TokenY = UnityEngine.Random.Range(0, location.GetLength(1));

                    location[TokenX, TokenY] = -1;

                    GameObject obj = Instantiate(Token) as GameObject;
                    obj.transform.position = new Vector3(TokenX, TokenY, 0);
                    obj.name = "Token";


                }

                else if (location[snakeX, snakeY] != 0)
                {
                    lost = true;
                    Debug.Log("You lost");
                    return;
                }

                location[snakeX, snakeY] = SnakeScore;
                SnakeTransform.position += direction;
            }
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
        }

    }
}
