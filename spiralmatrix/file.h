#define SEEK while(*sp != '\0'){sp++;}
//finds the end of a string
#define DISCARD while(getchar() != '\n'){}
//discards any extra characters left in input stream

int save(int** matrix, int n, char dir, char spindir[4]);
int init(int n, int** matrix);
int** load(int* n, char* dir, char spindir[4]);