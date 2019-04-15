using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockWood : Block
{

    public BlockWood()
        : base()
    {
		blockId = 3;
		blockHp = 5.0f;
		moltenTemp = 100f;
	//	if(molten){
	//		EditTerrain.SetBlock(pos, new BlockAir());
	//	}
	//	if(currentTemp >= moltenTemp){
	//		molten = true;
	//	} else {
	//		molten = false;
	//	}
    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.up:
                tile.x = 2;
                tile.y = 1;
                return tile;
            case Direction.down:
                tile.x = 2;
                tile.y = 1;
                return tile;
        }

        tile.x = 1;
        tile.y = 1;

        return tile;
    }
}