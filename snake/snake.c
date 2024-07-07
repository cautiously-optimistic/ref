#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define height 10
#define width 20

#ifdef _WIN32
#define CLEAR "cls"
#else
#define CLEAR "clear"
#endif

int init_field(char field[height][width], int apples){
    for(int i = 0; i < height; i++){
        for(int j = 0; j < width; j++){
            field[i][j] = ' ';
        }
    }

    int n = 0;
    int applex;
    int appley;
    while(n < apples){
        applex = rand()%width;
        appley = rand()%height;
        if(field[appley][applex] == ' '){
            field[appley][applex] = 'a';
            n++;
        }
    }
    return 0;
}

int init_snake(int snake[9][2]){
    snake[0][0] = 0;
    snake[0][1] = 8;
    for(int i = 1; i < 9; i++){
        snake[i][0] = 0;
        snake[i][1] = 9 - i - 1;
    }

    return 0;
}

int print_game(char field[height][width], int snake[9][2]){
    char wfield[height][width];
    for(int i = 0; i < height; i++){
        for(int j = 0; j < width; j++){
            wfield[i][j] = field[i][j];
        }
    }

    wfield[snake[0][0]][snake[0][1]] = '8';
    for(int i = 1; i < 9; i++){
        wfield[snake[i][0]][snake[i][1]] = '0';
    }

    system(CLEAR);
    for(int i = 0; i < 22; i++){
        printf("#");
    }
    printf("\n");
    for(int i = 0; i < height; i++){
        printf("#");
        for(int j = 0; j < width; j++){
            printf("%c", wfield[i][j]);
        }
        printf("#\n");
    }
    for(int i = 0; i < 22; i++){
        printf("#");
    }
    printf("\n");
    return 0;
}

/*returns:
0: simple move
1: got an apple
-1: hit boundary
-2: hit tail
-3: invalid move
*/
int update_snake(char field[height][width], int snake[9][2], char move){
    if(move != 'a' && move != 'd' && move != 'w' && move != 's'){
        return -3;
    }
    for(int i = 8; i > 0; i--){
        snake[i][0] = snake[i-1][0];
        snake[i][1] = snake[i-1][1];
    }
    switch(move){
        case 'a':{
            snake[0][1] = snake[0][1]-1;
            break;
        }
        case 'd':{
            snake[0][1] = snake[0][1]+1;
            break;
        }
        case 'w':{
            snake[0][0] = snake[0][0]-1;
            break;
        }
        case 's':{
            snake[0][0] = snake[0][0]+1;
            break;
        }
    }
    if(snake[0][1] < 0 || snake[0][1] == width || snake[0][0] < 0 || snake[0][0] == height){
        return -1;
    }
    int i = 1;
    while(i < 9 && !(snake[0][0] == snake[i][0] && snake[0][1] == snake[i][1])){
        i++;
    }
    if(i < 9){
        return -2;
    }
    if(field[snake[0][0]][snake[0][1]] == 'a'){
        field[snake[0][0]][snake[0][1]] = ' ';
        return 1;
    }
    return 0;
}

int main(){
    char field[height][width];
    int apples = 10;
    int snake[9][2];
    char move;
    int result;

    srand(time(NULL));

    init_field(field, apples);
    init_snake(snake);
    print_game(field, snake);
    
    do{
        scanf(" %c", &move);
        result = update_snake(field, snake, move);
        print_game(field, snake);
        if(result == 1){
            apples -= 1;
            printf("got an apple\n");
        } else {
            if(result == -3){
                printf("invalid move\n");
            }
        }
    } while((result == 0 || result == 1 || result == -3) && apples != 0);

    if(apples == 0){
        printf("win\n");
    } else {
        if(result == -1){
            printf("hit boundary\n");
        } else {
            printf("hit tail\n");
        }
    }
    return 0;
}