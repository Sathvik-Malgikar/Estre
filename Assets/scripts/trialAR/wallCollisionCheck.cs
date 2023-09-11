
using UnityEngine;


public class wallCollisionCheck : MonoBehaviour
{
    public static bool invalidPos=false;
    public Material ghost;
  


    public void setghost(Material val)
    {
        //Debug.Log("setghost called!"+val.name,this);
        ghost = val; 
    }


    public void repaint()
    {
      
        //Debug.Log("repaint called " + invalidPos + ghost.name + ColourST.currentMat, this);
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            int n = mr.materials.Length;
            Material[] mtrs = new Material[n];
        if (!invalidPos)
        {
            //Debug.Log("painting colour " + ColourST.currentColor,this);
            for (int i = 0; i < n; i++)
            {
                mtrs[i] = ColourST.currentMat;
            }
            mr.materials = mtrs;
        }
        else
        {
           
            //Debug.Log("painting colour ghost " ,this);
            for (int i = 0; i < n; i++)
            {
                mtrs[i] = ghost;
            }
            mr.materials = mtrs;
        }
        
     
    }

    

    public void Start()
    {
 
        invalidPos = false;
    }

    public void OnTriggerEnter(Collider collision)
    { 
        Debug.Log ("trig enter within furniture");
         
        if (collision.gameObject.CompareTag("Obstruction"))
        {
            Debug.Log("collision with Obstruction");
            invalidPos = true;
            repaint();
            Debug.Log(collision.gameObject.transform.position );
           
        }
        else
        {

            Debug.Log("collision with ARPlane or something else");
         
        }
    }

    private void OnTriggerExit(Collider collision)
    {
       
        
        if (collision.gameObject.CompareTag("Obstruction"))
        {
            Debug.Log("collision exit with Obstruction");
            invalidPos = false;
            repaint();
            Debug.Log(collision.gameObject.transform.position );
           
        }
        
    }
}