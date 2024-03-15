using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
;        /*gameObject.SetActive(false);*/ // Не используем, потому что безосновательно перестает включаться конечный экран при откидывании от взрыва гранаты
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
