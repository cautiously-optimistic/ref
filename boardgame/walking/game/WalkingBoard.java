package walking.game;
import walking.game.util.Direction;

public class WalkingBoard{
    private int[][] tiles;
    private int x;
    private int y;
    public static final int BASE_TILE_SCORE = 3;

    public WalkingBoard(int size){
        tiles = new int[size][size];
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                tiles[i][j] = BASE_TILE_SCORE;
            }
        }
        x = 0;
        y = 0;
    }

    public WalkingBoard(int[][] init){
        tiles = new int[init.length][init[0].length];
        for(int i = 0; i < tiles.length; i++){
            for(int j = 0; j < tiles[i].length; j++){
                tiles[i][j] = (init[i][j] < BASE_TILE_SCORE ? BASE_TILE_SCORE : init[i][j]);
            }
        }
        x = 0;
        y = 0;
    }

    public int[] getPosition(){
        int[] pos = {x, y};
        return pos;
    }

    public int getTile(int x, int y){
        if(!isValidPosition(x, y)){
            throw new IllegalArgumentException();
        }
        return tiles[x][y];
    }

    public boolean isValidPosition(int x, int y){
        return (x >= 0 && x < tiles.length && y >= 0 && y < tiles[0].length);
    }

    public int[][] getTiles(){
        int[][] result = new int[tiles.length][tiles[0].length];
        for(int i = 0; i < result.length; i++){
            for(int j = 0; j < result[i].length; j++){
                result[i][j] = tiles[i][j];
            }
        }
        return result;
    }

    public static int getXStep(Direction direction){//x: sor, y: oszlop
        switch(direction){
            case Direction.UP:
                return -1;
            case Direction.DOWN:
                return 1;
            default:
                return 0;
        }
    }

    public static int getYStep(Direction direction){
        switch(direction){
            case Direction.LEFT:
                return -1;
            case Direction.RIGHT:
                return 1;
            default:
                return 0;
        }
    }

    public int moveAndSet(Direction direction, int value){
        try{
            int oldv = getTile(x + getXStep(direction), y + getYStep(direction));
            x += getXStep(direction);
            y += getYStep(direction);
            tiles[x][y] = value;
            return oldv;

        }catch(IllegalArgumentException iae){
            return 0;
        }
    }
}