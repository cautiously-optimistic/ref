#define DISCARD while(getchar() != '\n'){}
//discards any extra characters left in input stream

#define CW (spindir[0] == 'c' && spindir[1] == 'w' && spindir[2] == '\0')
#define CCW (spindir[0] == 'c' && spindir[1] == 'c' && spindir[2] == 'w' && spindir[3] == '\0')

int center(int n, char dir, char spindir[3], int* x, int* y);
int generate(int n, int** matrix, char dir, char spindir[4], int x, int y);
int init(int n, int** matrix);
int** genmain(int* n, char* dir, char spindir[4]);