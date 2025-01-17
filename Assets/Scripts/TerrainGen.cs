﻿using UnityEngine;
using System.Collections;
using SimplexNoise;

public class TerrainGen
{

    float stoneBaseHeight = -210;//24
    float stoneBaseNoise = 0.05f;
    float stoneBaseNoiseHeight = 4;

    float stoneMountainHeight = 48;//48
    float stoneMountainFrequency = 0.008f;//0.008f
    float stoneMinHeight = -82; //-12

    float dirtBaseHeight = 1;
    float dirtNoise = 0.04f;
    float dirtNoiseHeight = 3;

    float caveFrequency = 0.025f;
    int caveSize = 7;

    float treeFrequency = 0.2f;//0.2f
    int treeDensity = 3;

	float ironFrequency = 0.03f;
	int ironSize = 3;

	float coalFrequency = 0.04f;
	int coalSize = 5;

    public Chunk ChunkGen(Chunk chunk)
	{
        for (int x = chunk.pos.x - 3; x < chunk.pos.x + Chunk.chunkSize + 3; x++) //Change this line
        {
            for (int z = chunk.pos.z - 3; z < chunk.pos.z + Chunk.chunkSize + 3; z++)//and this line
            {
                chunk = ChunkColumnGen(chunk, x, z);
            }
        }
        return chunk;
	}

    public Chunk ChunkColumnGen(Chunk chunk, int x, int z)
    {
        int stoneHeight = Mathf.FloorToInt(stoneBaseHeight);
        stoneHeight += GetNoise(x, 0, z, stoneMountainFrequency, Mathf.FloorToInt(stoneMountainHeight));

        if (stoneHeight < stoneMinHeight)
            stoneHeight = Mathf.FloorToInt(stoneMinHeight);

        stoneHeight += GetNoise(x, 0, z, stoneBaseNoise, Mathf.FloorToInt(stoneBaseNoiseHeight));

        int dirtHeight = stoneHeight + Mathf.FloorToInt(dirtBaseHeight);
        dirtHeight += GetNoise(x, 100, z, dirtNoise, Mathf.FloorToInt(dirtNoiseHeight));

        for (int y = chunk.pos.y - 8; y < chunk.pos.y + Chunk.chunkSize; y++)
        {
            //Get a value to base cave generation on
            int caveChance = GetNoise(x, y, z, caveFrequency, 100);

            if (y <= stoneHeight && caveSize < caveChance)
            {
                
				if(GetNoise(x, y, z, ironFrequency, 100) < ironSize){
					SetBlock(x, y, z, new BlockIron(), chunk);
				}else if(GetNoise(x, y, z, coalFrequency, 100) < coalSize){
					SetBlock(x, y, z, new BlockCoal(), chunk);
				}else{
					SetBlock(x, y, z, new Block(), chunk);
				}
            }
            else if (y <= dirtHeight && caveSize < caveChance)
            {
                SetBlock(x, y, z, new BlockGrass(), chunk);

                if (y == dirtHeight && GetNoise(x, 0, z, treeFrequency, 100) < treeDensity)
                    CreateTree(x, y + 1, z, chunk);
            }
            else
            {
                SetBlock(x, y, z, new BlockAir(), chunk);
            }

        }

        return chunk;
    }

    void CreateTree(int x, int y, int z, Chunk chunk)
    {
        //create leaves
        for (int xi = -2; xi <= 2; xi++)
        {
            for (int yi = 4; yi <= 8; yi++)
            {
                for (int zi = -2; zi <= 2; zi++)
                {
					if(!( (zi == -2 || zi == 2) && (xi == -2 || xi == 2) ) && yi == 4){
                    	SetBlock(x + xi, y + yi, z + zi, new BlockLeaves(), chunk, true);
					}else if(yi > 4 && yi <= 6){
						SetBlock(x + xi, y + yi, z + zi, new BlockLeaves(), chunk, true);
					}else if(yi == 7 && !((zi == -2 || zi == 2) && (xi == -2 || xi == 2))){
						SetBlock(x + xi, y + yi, z + zi, new BlockLeaves(), chunk, true);
					}else if(yi == 8 && ((xi == 0 && (zi == -1 || zi == 0 || zi == 1) || (zi == 0 && (xi == -1 || xi == 1))))){
						SetBlock(x + xi, y + yi, z + zi, new BlockLeaves(), chunk, true);
					}
				}
            }
        }

        //create trunk
        for (int yt = 0; yt < 6; yt++)
        {
            SetBlock(x, y + yt, z, new BlockWood(), chunk, true);
        }
    }

    public static void SetBlock(int x, int y, int z, Block block, Chunk chunk, bool replaceBlocks = false)
    {
        x -= chunk.pos.x;
        y -= chunk.pos.y;
        z -= chunk.pos.z;

        if (Chunk.InRange(x) && Chunk.InRange(y) && Chunk.InRange(z))
        {
            if (replaceBlocks || chunk.blocks[x, y, z] == null)
                chunk.SetBlock(x, y, z, block);
        }
    }

    public static int GetNoise(int x, int y, int z, float scale, int max)
    {
        return Mathf.FloorToInt((Noise.Generate(x * scale, y * scale, z * scale) + 1f) * (max / 2f));
    }
}