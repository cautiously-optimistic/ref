#include <stdio.h>
#include <stdlib.h>
#include "gen.h"

int center(int n, char dir, char spindir[3], int* x, int* y){
    if(n%2 == 1){
        *x = n/2;
        *y = n/2;
        return 0;
    } else {
        switch(dir){
            case 'l':{
                if(CW){
                    *x = n/2;
                    *y = n/2;
                } else {
                    *x = n/2;
                    *y = n/2-1;
                }
                return 0;
            }
            case 'r':{
                if(CW){
                    *x = n/2-1;
                    *y = n/2-1;
                } else {
                    *x = n/2-1;
                    *y = n/2;
                }
                return 0;
            }
            case 'u':{
                if(CW){
                    *x = n/2-1;
                    *y = n/2;
                } else {
                    *x = n/2;
                    *y = n/2;
                }
                return 0;
            }
            case 'd':{
                if(CW){
                    *x = n/2;
                    *y = n/2-1;
                } else {
                    *x = n/2-1;
                    *y = n/2-1;
                }
                return 0;
            }
            default:{
                return 1;
            }
        }
    }
    return 1;
}

int generate(int n, int** matrix, char dir, char spindir[4], int x, int y){
    int num = 2;
    matrix[x][y] = 1;
    while(num <= n*n){
        switch(dir){
            case 'l':{
                if(CW){
                    do{
                        x--;
                        matrix[x][y] = num;
                        num++;
                    }while(x >= 0 && matrix[x][y-1] != 0 && num <= n*n);
                    dir = 'u';
                } else {
                    do{
                        x--;
                        matrix[x][y] = num;
                        num++;
                    }while(x >= 0 && matrix[x][y+1] != 0 && num <= n*n);
                    dir = 'd';
                }
                break;
            }
            case 'r':{
                if(CW){
                    do{
                        x++;
                        matrix[x][y] = num;
                        num++;
                    }while(x < n && matrix[x][y+1] != 0 && num <= n*n);
                    dir = 'd';
                } else {
                    do{
                        x++;
                        matrix[x][y] = num;
                        num++;
                    }while(x < n && matrix[x][y-1] != 0 && num <= n*n);
                    dir = 'u';
                }
                break;
            }
            case 'u':{
                if(CW){
                    do{
                        y--;
                        matrix[x][y] = num;
                        num++;
                    }while(y >= 0 && matrix[x+1][y] != 0 && num <= n*n);
                    dir = 'r';
                } else {
                    do{
                        y--;
                        matrix[x][y] = num;
                        num++;
                    }while(y >= 0 && matrix[x-1][y] != 0 && num <= n*n);
                    dir = 'l';
                }
                break;
            }
            case 'd':{
                if(CW){
                    do{
                        y++;
                        matrix[x][y] = num;
                        num++;
                    }while(y <n && matrix[x-1][y] != 0 && num <= n*n);
                    dir = 'l';
                } else {
                    do{
                        y++;
                        matrix[x][y] = num;
                        num++;
                    }while(y < n && matrix[x+1][y] != 0 && num <= n*n);
                    dir = 'r';
                }
                break;
            }
        }
    }
    return 0;
}

int** genmain(int* n, char* dir, char spindir[4]){
    int x;
    int y;
    
    printf("Matrix size (1-20): ");
    while(scanf("%d", n) != 1 || *n < 1 || *n > 20 || getchar() != '\n'){
        DISCARD
        printf("Incorrect input. Please enter a number between 1 and 20.\n");
    }
    int** matrix = malloc(sizeof(int*)*(*n));
    printf("Starting direction (u - up, d - down, l - left, r - right): ");
    while(scanf(" %c", dir) != 1 || getchar() != '\n' || !(*dir == 'u' || *dir == 'd' || *dir == 'l' || *dir == 'r')){
        DISCARD
        printf("Incorrect input. Please only enter the letters u, d, l or r.\n");
    }
    printf("Clockwise (cw) or counter-clockwise (ccw): ");
    while(scanf(" %s", spindir) != 1 || !(CW || CCW)){
        DISCARD
        printf("Incorrect input. Please only enter 'cw' or 'ccw'.\n");
    }

    if(matrix){
        if(!init((*n), matrix)){
            center((*n), *dir, spindir, &x, &y);
            generate((*n), matrix, *dir, spindir, x, y);
            
            return matrix;
        }
    }
    printf("Malloc failed.\n");
    return 0;
}