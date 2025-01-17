﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockAir : Block
{
    public BlockAir()
        : base()
    {
		blockId = 0;
		blockHp = 0f;
    }

    public override MeshData Blockdata
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        return meshData;
    }

    public override bool IsSolid(Block.Direction direction)
    {
        return false;
    }
}