package walking.game;

import walking.game.WalkingBoard;
import walking.game.player.Player;
import walking.game.util.Direction;
import walking.game.player.MadlyRotatingBuccaneer;
import walking.game.WalkingBoardWithPlayers;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class WalkingBoardWithPlayersTest{

    @Test
    public void walk1(){
        WalkingBoardWithPlayers board = new WalkingBoardWithPlayers(5, 3);

        //scores
        int[] expected = {15, 24, 15};
        int[] result = board.walk(2, 1, 2, 1, 1, 2, 3, 2, 3, 2, 2, 1);
        for(int i = 0; i < 3; i++){
            assertEquals(expected[i], result[i]);
        }

        //board
        //{3, 2, 3, 4, 5}
        //{13, 3, 3, 3, 6}
        //{13, 3, 3, 3, 7}
        //{13, 11, 10, 9, 8}
        //{13, 3, 3, 3, 3}
        int[][] expectedBoard = {{3, 2, 3, 4, 5}, {13, 3, 3, 3, 6}, {13, 3, 3, 3, 7}, {13, 11, 10, 9, 8}, {13, 3, 3, 3, 3}};
        for(int i = 0; i < board.getTiles().length; i++){
            for(int j = 0; j < board.getTiles()[0].length; j++){
                assertEquals(expectedBoard[i][j], board.getTile(i, j));
            }
        }
    }

    @Test
    public void walk2(){
        int[][] array = {{2, 4, 5, 9, 6}, {3, 5, 1, 7, 4}, {0, 8, 4, 2, 3}};//3x5
        WalkingBoardWithPlayers board = new WalkingBoardWithPlayers(array, 4);

        //scores
        int[] expected = {18, 16, 18, 3};
        int[] result = board.walk(3, 2, 4, 1, 5, 6, 2, 7, 4, 3, 5, 7, 2, 0, 1, 1);
        for(int i = 0; i < 4; i++){
            assertEquals(expected[i], result[i]);
        }

        //board
        int[][] expectedBoard = {{13, 3, 4, 5, 6}, {13, 5, 3, 7, 13}, {13, 13, 13, 13, 13}};
        for(int i = 0; i < board.getTiles().length; i++){
            for(int j = 0; j < board.getTiles()[0].length; j++){
                assertEquals(expectedBoard[i][j], board.getTile(i, j));
            }
        }
    }
}