#include <stdio.h>
#include <stdlib.h>
#include "file.h"

int save(int** matrix, int n, char dir, char spindir[4]){
    char name[100] = "spiral";
    char* sp = name;

    SEEK
    sprintf(sp, "%d", n);
    SEEK
    sprintf(sp, "%c", dir);
    sp++;
    sprintf(sp, "%s", spindir);
    SEEK
    sprintf(sp, ".txt");
    
    FILE* fp = fopen(name, "w");
    fprintf(fp,"%d %c %s",n, dir, spindir);
    fclose(fp);

    fp = fopen(name, "a");
    for(int i = 0; i < n; i++){
        fprintf(fp, "\n");
        for(int j = 0; j < n; j++){
            fprintf(fp, " %4d", matrix[j][i]);
        }
    }
    fclose(fp);

    printf("Matrix was saved as %s.\n", name);
    return 0;
}

int** load(int* n, char* dir, char spindir[4]){
    char input[100];
    FILE* fp = 0;
    printf("Please enter the file you'd like to open (filename.txt).\n");

    scanf(" %s", input);
    fp = fopen(input, "r");

    while(fp == NULL){
        printf("The file you entered doesn't exist. Please try again.\n");
        scanf(" %s", input);
        fp = fopen(input, "r");
    }

    fscanf(fp, "%d %c %s", n, dir, spindir);
    
    int** matrix = malloc(sizeof(int*)*(*n));
    if(!matrix || init(*n, matrix)){
        fclose(fp);
        return 0;
    }

    for(int i = 0; i < *n; i++){
        for(int j = 0; j < *n; j++){
            fscanf(fp, " %d", &(matrix[j][i]));
        }
    }
    fclose(fp);

    return matrix;
}