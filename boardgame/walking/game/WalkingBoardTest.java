package walking.game;
import walking.game.WalkingBoard;
import walking.game.util.Direction;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class WalkingBoardTest{
    @ParameterizedTest
    @CsvSource(textBlock = """
        1
        3
        6
    """)
    @DisableIfHasBadStructure
    public void testSimpleInit(int size) {
        WalkingBoard board = new WalkingBoard(size);

        assertEquals(size, board.getTiles().length);
        assertEquals(size, board.getTiles()[0].length);

        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                assertEquals(3, board.getTile(i, j));
            }
        }
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
        0, 1, 4
        1, 3, 7
        2, 0, 3
        0, 0, 3
    """)
    @DisableIfHasBadStructure
    public void testCustomInit(int x, int y, int expected) {//3x4
        int[][] array = {{2, 4, 5, 9}, {3, 5, 1, 7}, {0, 8, 4, 2}};
        WalkingBoard board = new WalkingBoard(array);
        assertEquals(expected, board.getTile(x, y));
        array[x][y] = 5;
        assertEquals(expected, board.getTile(x, y));
        board.getTiles()[x][y] = 5;
        assertEquals(expected, board.getTile(x, y));
    }

    @Test
    public void testMoves(){
        int[][] array = {{2, 4, 5, 9}, {3, 5, 1, 7}, {0, 8, 4, 2}};
        WalkingBoard board = new WalkingBoard(array);
        //{{3, 4, 5, 9}
        //{3, 5, 3, 7}
        //{3, 8, 4, 3}}

        assertEquals(3, board.getTile(board.getPosition()[0], board.getPosition()[1]));

        assertEquals(3, board.moveAndSet(Direction.DOWN, 4));
        assertEquals(1, board.getPosition()[0]);
        assertEquals(0, board.getPosition()[1]);
        assertEquals(4, board.getTile(board.getPosition()[0], board.getPosition()[1]));
        //{{3, 4, 5, 9}
        //{4, 5, 3, 7}
        //{3, 8, 4, 3}}

        assertEquals(0, board.moveAndSet(Direction.LEFT, 4));
        assertEquals(1, board.getPosition()[0]);
        assertEquals(0, board.getPosition()[1]);
        assertEquals(4, board.getTile(board.getPosition()[0], board.getPosition()[1]));

        assertEquals(5, board.moveAndSet(Direction.RIGHT, 7));
        assertEquals(1, board.getPosition()[0]);
        assertEquals(1, board.getPosition()[1]);
        assertEquals(7, board.getTile(board.getPosition()[0], board.getPosition()[1]));
        //{{3, 4, 5, 9}
        //{4, 7, 3, 7}
        //{3, 8, 4, 3}}

        assertEquals(8, board.moveAndSet(Direction.DOWN, 1));
        assertEquals(2, board.getPosition()[0]);
        assertEquals(1, board.getPosition()[1]);
        assertEquals(1, board.getTile(board.getPosition()[0], board.getPosition()[1]));
        //{{3, 4, 5, 9}
        //{4, 7, 3, 7}
        //{3, 1, 4, 3}}

        assertEquals(0, board.moveAndSet(Direction.DOWN, 7));
        assertEquals(2, board.getPosition()[0]);
        assertEquals(1, board.getPosition()[1]);
        assertEquals(1, board.getTile(board.getPosition()[0], board.getPosition()[1]));
        //{{3, 4, 5, 9}
        //{4, 7, 3, 7}
        //{3, 1, 4, 3}}

        assertEquals(3, board.moveAndSet(Direction.LEFT, 5));
        assertEquals(2, board.getPosition()[0]);
        assertEquals(0, board.getPosition()[1]);
        assertEquals(5, board.getTile(board.getPosition()[0], board.getPosition()[1]));
        //{{3, 4, 5, 9}
        //{4, 7, 3, 7}
        //{5, 1, 4, 3}}
    }
}