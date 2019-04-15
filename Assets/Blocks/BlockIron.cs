using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockIron : Block
{
	
	public BlockIron()
		: base()
	{
		blockId = 5;
		blockHp = 15.0f;
		moltenTemp = 1500f;
	}
	
	public override Tile TexturePosition(Direction direction)
	{
		Tile tile = new Tile();
		
		tile.x = 1;
		tile.y = 2;
		
		return tile;
	}

}