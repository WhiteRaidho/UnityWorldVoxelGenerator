﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockGrass : Block
{

    public BlockGrass()
        : base()
    {
		blockId = 2;
		blockHp = 2.5f;
		moltenTemp = 100f;
    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.up:
                tile.x = 2;
                tile.y = 0;
                return tile;
            case Direction.down:
                tile.x = 1;
                tile.y = 0;
                return tile;
        }

        tile.x = 3;
        tile.y = 0;

        return tile;
    }
}