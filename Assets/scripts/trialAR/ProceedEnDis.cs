using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProceedEnDis : MonoBehaviour
{
    //private PlaceSeat plst;

    // Start is called before the first frame update
    void Start()
    {
        //plst = FindObjectOfType<PlaceSeat>();
    }

    public void goToFineTune()
    {
        SceneManager.LoadScene("fineTuning", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlaceSeat.gotemp != null) {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
       
    }
}
