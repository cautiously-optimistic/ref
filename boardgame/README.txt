Description:
A collection of classes for simulating a board game which involves a single piece moving around on a board while controlled by multiple players. The board is divided into tiles which each have a score assigned to them. The players each take steps with the piece, often multiple at a time, claiming the points on and assigning new scores to the tiles they've stepped on.

Directory overview:
The classes are written to adhere to pre-written structure tests available at walking/game/tests. The source files are in the folder walking/game, as well as its player and util subfolders. Walking/game also contains two unit test files which check the correct functioning of the classes. The tests can be run using JUnit, either separately or using one of the test suites in walking/game/tests (walking/game/tests/WalkingBoardFullTestSuite.java runs all structure and unit tests).

Pre-written files (code not written by me): everything in walking/game/tests

Class overview (assuming walking/game as working directory):
- WalkingBoard: Parent class to WalkingBoardWithPlayers. Describes the game board by the scores assigned to its tiles and the position of the piece. Contains methods for creating the board and taking a step with the piece.
- WalkingBoardWithPlayers: Child class of WalkingBoard which enables the simulation of the game. Beyond the members of its parent class, it stores the players and tracks the number of rounds that have elapsed. Contains methods for setting up the game and simulating the players' steps.
- util.Direction: An enum of the directions the piece can move in (up, down, left, right).
- player.Player: Describes a player by their score. Contains methods for showing and updating the score and changing directions (turning).
- player.MadlyRotatingBuccaneer: Child class of Player. A specific kind of player that changes directions differently. Contains an override for the base turn method.
- WalkingBoardTest and WalkingBoardWithPlayersTest: Test classes checking the correct functioning of WalkingBoard and WalkingBoardWithPlayers.