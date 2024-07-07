package walking.game;
import walking.game.WalkingBoard;
import walking.game.player.Player;
import walking.game.util.Direction;
import walking.game.player.MadlyRotatingBuccaneer;

public class WalkingBoardWithPlayers extends WalkingBoard{
    private Player[] players;
    private int round;
    public static final int SCORE_EACH_STEP = 13;

    public WalkingBoardWithPlayers(int[][] board, int playerCount){
        super(board);
        initPlayers(playerCount);
        round = 0;
    }

    public WalkingBoardWithPlayers(int size, int playerCount){
        super(size);
        initPlayers(playerCount);
        round = 0;
    }

    private void initPlayers(int playerCount){
        if(playerCount < 2){
            throw new IllegalArgumentException();
        }
        players = new Player[playerCount];
        players[0] = new MadlyRotatingBuccaneer();
        for(int i = 1; i < playerCount; i++){
            players[i] = new Player();
        }
    }

    public int[] walk(int... stepCounts){
        int steps = 0;
        for(int i = 0; i < stepCounts.length; i++){
            if(i%players.length == 0){
                round++;
            }
            players[i%players.length].turn();
            for(int j = 0; j < stepCounts[i]; j++){
                players[i%players.length].addToScore(moveAndSet(players[i%players.length].getDirection(), (steps < SCORE_EACH_STEP ? steps : SCORE_EACH_STEP)));
                steps++;
            }
        }
        int[] points = new int[players.length];
        for(int i = 0; i < players.length; i++){
            points[i] = players[i].getScore();
        }
        return points;
    }
}