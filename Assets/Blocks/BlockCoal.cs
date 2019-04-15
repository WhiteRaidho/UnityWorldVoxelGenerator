using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockCoal : Block {

	public BlockCoal()
		: base(){
		blockId = 6;
		blockHp = 7.5f;
		moltenTemp = 750f;
	}


	public override Tile TexturePosition(Direction direction)
	{
		Tile tile = new Tile();
		
		tile.x = 0;
		tile.y = 3;
		
		return tile;
	}
}
