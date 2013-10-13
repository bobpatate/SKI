using UnityEngine;
using System.Collections;

public class SpriteSheet : MonoBehaviour {

	public int colCount = 5;
	public int rowCount = 5;
	 
	//vars for animation
	public int rowNumber = 0; //Zero Indexed
	public int colNumber = 0; //Zero Indexed
	public int totalCells = 5;
	public int fps = 24;	
	
    //Maybe this should be a private var
    private Vector2 offset;
	private int previousIndex = 0;
	private bool stopLoop = false;
	private int cptChangeFrame = 0;
	
	public int etat = 0;
	
	//Update
	void Update () {
		switch(etat){
		case 0:
			SetSpriteAnimation(colCount,rowCount,0,colNumber,1,fps);  
			break;
		case 1:
			SetSpriteAnimation(colCount,rowCount,1,colNumber,5,fps); 
			break;
		case 2:
			SetSpriteAnimation(colCount,rowCount,2,colNumber,5,fps);  
			break;
		}
	}
	 
	//SetSpriteAnimation
	void SetSpriteAnimation(int colCount ,int rowCount ,int rowNumber ,int colNumber,int totalCells,int fps ){
		
	 	int index  = (int)(Time.time * fps);
	    // Calculate index
		if(stopLoop == true){
			cptChangeFrame++;
			if(cptChangeFrame > 14){
				etat = 0;
				rowNumber = 0;
				colNumber = 0;
				totalCells = 1;
				index = 0;
				previousIndex = 0;
				cptChangeFrame = 0;
				stopLoop = false;
			}else{
	    		index = 4;
			}
		}
		
	    // Repeat when exhausting all cells
		if(index % totalCells == 0 && previousIndex == 4){
		    index = 4;
			previousIndex = index;
			stopLoop = true;
		}else{
			index = index % totalCells;
	 		previousIndex = index;
		}
		
	    // Size of every cell
	    float sizeX = 1.0f / colCount;
	    float sizeY = 1.0f / rowCount;
	    Vector2 size =  new Vector2(sizeX,sizeY);
	 
	    // split into horizontal and vertical index
	    var uIndex = index % colCount;
	    var vIndex = index / colCount;
	 
	    // build offset
	    // v coordinate is the bottom of the image in opengl so we need to invert.
	    float offsetX = (uIndex+colNumber) * size.x;
	    float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
	    Vector2 offset = new Vector2(offsetX,offsetY);
	 
	    renderer.material.SetTextureOffset ("_MainTex", offset);
	    renderer.material.SetTextureScale  ("_MainTex", size);
	}
}