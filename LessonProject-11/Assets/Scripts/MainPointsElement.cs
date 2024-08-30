using UnityEngine;

public class MainPointsElement : MonoBehaviour
{
    private Vector3 [] positions = new Vector3 [2];

    [SerializeField] private float radius;
    [SerializeField] private float speed;

    [SerializeField] private char coordinate;

    private int numP;

    private void Start()
    {
        numP = Random.Range(0,2);
        if(coordinate == 'z')
        {
            positions[0] = gameObject.transform.position - new Vector3(0, 0, radius);
            positions[1] = gameObject.transform.position + new Vector3(0, 0, radius);
        }
        else if (coordinate == 'x')
        {
            positions[0] = gameObject.transform.position - new Vector3(radius, 0, 0);
            positions[1] = gameObject.transform.position + new Vector3(radius, 0, 0);
        }
        else if (coordinate == 'y')
        {
            positions[0] = gameObject.transform.position - new Vector3(0, radius, 0);
            positions[1] = gameObject.transform.position + new Vector3(0, radius, 0);
        }
    }

    private void Update()
    {
        if (gameObject.transform.position != positions[numP]) 
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, positions[numP],Time.deltaTime*speed);
        }
        else
        {
            numP++;
            if(numP == positions.Length) 
            {
                numP = 0;
            }
        }
    }
}
