
using System.Collections;
using UnityEngine;

public class CursorFade : MonoBehaviour
{
    private Coroutine coHideCursor_;

    private IEnumerator HideCursor()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse X") == 0 && (Input.GetAxis("Mouse Y") == 0))
        {
            if (coHideCursor_ == null)
            {
                coHideCursor_ = StartCoroutine(HideCursor());
            }
        }
        else
        {
            if (coHideCursor_ != null)
            {
                StopCoroutine(coHideCursor_);
                coHideCursor_ = null;
                Cursor.visible = true;
            }
        }
    }
}
