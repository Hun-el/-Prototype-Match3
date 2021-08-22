using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchFinder : MonoBehaviour
{
    Board board;
    public List<Gem> currentMatches = new List<Gem>();

    private void Awake() {
        board = FindObjectOfType<Board>();
    }

    public void FindAllMatches()
    {
        currentMatches.Clear();

        for(float x = 0; x < board.Width; x++)
        {
            for(float y = 0; y < board.Height; y++)
            {
                if(x > 0 && x < board.Width - 1)
                {
                    Gem currentGem = board.allGems[(int)x,(int)y];
                    if(currentGem != null)
                    {
                        Gem leftGem = board.allGems[(int)x-1,(int)y];
                        Gem rightGem = board.allGems[(int)x+1,(int)y];
                        if(leftGem != null && rightGem != null)
                        {
                            if(leftGem.type == currentGem.type && rightGem.type == currentGem.type)
                            {
                                currentGem.isMatched = true;
                                leftGem.isMatched = true;
                                rightGem.isMatched = true;

                                currentMatches.Add(currentGem);
                                currentMatches.Add(leftGem);
                                currentMatches.Add(rightGem);
                            }
                        }
                    }
                }

                if(y > 0 && y < board.Height - 1)
                {
                    Gem currentGem = board.allGems[(int)x,(int)y];
                    if(currentGem != null)
                    {
                        Gem aboveGem = board.allGems[(int)x,(int)y+1];
                        Gem belowGem = board.allGems[(int)x,(int)y-1];
                        if(aboveGem != null && belowGem != null)
                        {
                            if(aboveGem.type == currentGem.type && belowGem.type == currentGem.type)
                            {
                                currentGem.isMatched = true;
                                aboveGem.isMatched = true;
                                belowGem.isMatched = true;

                                currentMatches.Add(currentGem);
                                currentMatches.Add(aboveGem);
                                currentMatches.Add(belowGem);
                            }
                        }
                    }
                }
            }
        }
        CheckBomb();
    }

    void CheckBomb()
    {
        for(int x = 0; x < board.Width; x++)
        {
            for(int y = 0; y < board.Height; y++)
            {
                Gem gem = board.allGems[x,y];

                if(board.allGems[x,y].type == Gem.GemType.bomb)
                {
                    MarkBombArea(gem.pos , gem);
                }
            }
        }
    }

    void MarkBombArea(Vector2 bombPos , Gem bomb)
    {
        for(int x = (int)bombPos.x - bomb.blastSize; x <= bombPos.x + bomb.blastSize; x++)
        {
            for(int y = (int)bombPos.y - bomb.blastSize; y <= bombPos.y + bomb.blastSize; y++)
            {
                if(x >= 0 && x < board.Width && y >= 0 && y < board.Height)
                {
                    if(board.allGems[x,y] != null)
                    {
                        board.allGems[x,y].isMatched = true;
                        board.allGems[x,y].destroyEffect = board.allGems[x,y].bombEffect;
                        currentMatches.Add(board.allGems[x,y]);
                    }
                }
            }
        }
    }

    public void CheckBoard()
    {
        for(float x = 0; x < board.Width; x++)
        {
            for(float y = 0; y < board.Height; y++)
            {
                if(x > 0)
                {
                    Gem currentGem = board.allGems[(int)x,(int)y];
                    if(currentGem != null)
                    {
                        Gem leftGem = board.allGems[(int)x-1,(int)y];
                        if(leftGem != null)
                        {
                            if(leftGem.type == currentGem.type)
                            {
                                if(x > 1)
                                {
                                    if(y != board.Height - 1)
                                    {
                                        Gem gem1 = board.allGems[(int)x-2,(int)y+1];
                                        if(leftGem.type == gem1.type)
                                        {
                                            print("Eşleşme var.");
                                        }
                                    }
                                    if(y != 0)
                                    {
                                        Gem gem2 = board.allGems[(int)x-2,(int)y-1];
                                        if(leftGem.type == gem2.type)
                                        {
                                            print("Eşleşme var.");
                                        }
                                    }
                                }

                                if(x > 0 && x != board.Width - 1)
                                {
                                    if(y != board.Height - 1)
                                    {
                                        Gem gem1 = board.allGems[(int)x+1,(int)y+1];
                                        if(currentGem.type == gem1.type)
                                        {
                                            print("Eşleşme var.");
                                        }
                                    }
                                    if(y != 0)
                                    {
                                        Gem gem2 = board.allGems[(int)x+1,(int)y-1];
                                        if(currentGem.type == gem2.type)
                                        {
                                            print("Eşleşme var.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
