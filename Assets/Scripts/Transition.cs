
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float coordinateX = transform.parent.transform.position.x;
            float coordinateY = transform.parent.transform.position.y;

            if (coordinateX == 0)
            {
                if (coordinateY > 0)
                {
                    Level.CurrentPosition.MoveUp();
                }
                else
                {
                    Level.CurrentPosition.MoveDown();
                }
            }

            if (coordinateY == 0)
            {
                if (coordinateX > 0)
                {
                    Level.CurrentPosition.MoveRight();
                }
                else
                {
                    Level.CurrentPosition.MoveLeft();
                }
            }
            SceneManager.LoadScene(Level.Matrix());
        }
    }
}
