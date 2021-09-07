using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour{
	World world;
	Text text;
	
	float frameRate;
	float timer;
    float frameRateSum;
    float frames;
	
	int halfWorldSizeInVoxels;
	int halfWorldSizeInChunks;
	
	
    void Start(){
		world = GameObject.Find("World").GetComponent<World>();
		text = GetComponent<Text>();
		
		halfWorldSizeInVoxels = VoxelData.WorldSizeInVoxels / 2;
		halfWorldSizeInChunks = VoxelData.WorldSizeInChunks / 2;
    }


    void Update(){
		string debugText;
		debugText = frameRate + " fps \n";
		debugText += "X: "+(Mathf.FloorToInt(world.player.transform.position.x)-halfWorldSizeInVoxels)+"\n";
		debugText += "Y: "+Mathf.FloorToInt(world.player.transform.position.y)+"\n";
		debugText += "Z: "+(Mathf.FloorToInt(world.player.transform.position.z)-halfWorldSizeInVoxels)+"\n";
		debugText += "Chunk: "+(world.playerChunkCoord.x-halfWorldSizeInChunks)+", "+(world.playerChunkCoord.z-halfWorldSizeInChunks)+"\n";
		
		text.text = debugText;
		
		frames++;
		frameRateSum += 1f / Time.unscaledDeltaTime;
		
		if(timer > 0.5f){
			frameRate = (int)(frameRateSum/frames);
			timer = 0;
			frames = 0;
			frameRateSum = 0;
		}
		else
			timer += Time.deltaTime;
    }
}
