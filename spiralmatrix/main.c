#include <stdio.h>
#include <stdlib.h>
#include "gen.h"
#include "file.h"

#ifdef _WIN32
#define CLEAR "cls"
#else
#define CLEAR "clear"
#endif

int save(int** matrix, int n, char dir, char spindir[4]);

int user_guide(){
    printf("This program will allow you to create square spiral matrices, save them to or load them from txt files.\n");
    printf("Your options include:");
    printf("\n - Generate matrix: Allows you to generate a spiral matrix. You will be able to specify its size (nxn), the starting direction of its spiral (up, down, left, or right), and whether it will be clockwise or counter-clockwise.");
    printf("\nThe center of the matrix will always be 1.");
    printf("\n - Save matrix: You will be able to save the matrix you've generated to a .txt file. The first row will contain information such as its size and directions, then the matrix itself is displayed starting from the second row.");
    printf("\n - Load matrix: You will be able to import matrices you have previously saved by entering the name of the file they're saved in.");
    printf("\n - Print matrix: Displays the matrix currently open in the program (either loaded from a file or freshly generated).");
    printf("\n - Exit: Exits the program.\n");
    return 0;
}

int printmenu(){
    printf("|------ Menu --------|\n");
    printf("| 0: User guide      |\n");
    printf("| 1: Generate matrix |\n");
    printf("| 2: Save matrix     |\n");
    printf("| 3: Load matrix     |\n");
    printf("| 4: Print matrix    |\n");
    printf("| 5: Exit            |\n");
    printf("|====================|\n\n");

    return 0;
}

int exitsub(){ //exit subprograms
    DISCARD
    printf("\nPress Enter to return to the menu.\n"); //delays until user input
    DISCARD
    system(CLEAR);
    return 0;
}

int printmat(int n, int** matrix){
    if(matrix){
        if(matrix[n-1][n-1] < 10){
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    printf("%2d", matrix[j][i]);
                }
                printf("\n");
            }
            return 0;
        }
        if(matrix[n-1][n-1] < 100){
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    printf("%3d", matrix[j][i]);
                }
                printf("\n");
            }
            return 0;
        }
        for(int i = 0; i < n; i++){//the biggest possible number is less than 1000
            for(int j = 0; j < n; j++){
                printf("%4d", matrix[j][i]);
            }
            printf("\n");
        }
        return 0;
    } else {
        printf("No current matrix to print.\n");
    }
    return 0;
}

int init(int n, int** matrix){
    int i = 0;
    while(i < n && (i == 0 || matrix[i-1] != 0)){
        matrix[i] = malloc(sizeof(int)*n);
        i++;
    }
    if(i == n){
        for(int j = 0; j < n; j++){
            for(int k = 0; k < n; k++){
                matrix[j][k] = 0;
            }
        }
        return 0;
    }
    return 1;
}

int main(){
    int** matrix = 0;
    int n;
    char dir;
    char spindir[4];
    int choice;

    system(CLEAR);
    
    do{
        printmenu();
        
        printf("Your choice: ");
        while(scanf(" %d", &choice) != 1){
            DISCARD
            printf("Invalid input.\nYour choice: ");
        }

        system(CLEAR);

        switch(choice){
            case 0: {
                user_guide();
                exitsub();
                break;
            }
            case 1:{
                if(matrix){
                    for(int i = 0; i < n; i++){
                        free(matrix[i]);
                    }
                    free(matrix);
                }
                matrix = genmain(&n, &dir, spindir);
                if(matrix){
                    printf("\nMatrix generated successfully.\n");
                } else {
                    printf("\nMatrix generation failed.\n");
                }
                exitsub();
                break;
            }
            case 2:{
                if(matrix){
                    save(matrix, n, dir, spindir);
                } else {
                    printf("No current matrix to save.\n");
                }
                exitsub();
                break;
            }
            case 3:{
                if(matrix){
                    for(int i = 0; i < n; i++){
                        free(matrix[i]);
                    }
                    free(matrix);
                }
                matrix = load(&n, &dir, spindir);
                if(matrix){
                    printf("File loaded successfully.\n");
                } else {
                    printf("An error occurred while loading matrix.\n");
                }
                exitsub();
                break;
            }
            case 4:{
                printmat(n, matrix);
                exitsub();
                break;
            }
            case 5:{
                if(matrix){
                    for(int i = 0; i < n; i++){
                        free(matrix[i]);
                    }
                    free(matrix);
                }
                printf("Exit\n");
                break;
            }
            default:{
                printf("Invalid input. Please try again.\n");
            }
        }
    }while(choice != 5);

    return 0;
}