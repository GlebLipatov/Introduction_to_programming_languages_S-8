int size = 4;
int sideSize = size - 1;
int[,] matrix = new int[size, size];
int countRow = sideSize;
int countColumn = sideSize;
int currentDigit = 1;
int row = sideSize - countColumn;
int column = sideSize - countColumn;
int round = 1;

bool isTopSideToFill = true;
bool isRightSideToFill = false;
bool isBottomSideToFill = false;
bool isLeftSideToFill = false;

while (!isEnd(currentDigit, size))
{
    row = sideSize - countRow;
    column = sideSize - countColumn;

    if (isTopSideToFill)
    {
        matrix[row, column] = currentDigit++;
        countColumn--;

        if (sideSize - countColumn == sideSize)
        {
            isTopSideToFill = false;
            isRightSideToFill = true;
        }
    }
    else if (isRightSideToFill)
    {
        matrix[row, column] = currentDigit++;
        countRow--;

        if (sideSize - countRow == sideSize)
        {
            isRightSideToFill = false;
            isBottomSideToFill = true;
        }

    }
    else if (isBottomSideToFill)
    {
        matrix[row, column] = currentDigit++;
        countColumn++;

        if (sideSize - countColumn == 0)
        {
            isBottomSideToFill = false;
            isLeftSideToFill = true;
        }
    }
    else if (isLeftSideToFill)
    {
        matrix[row, column] = currentDigit++;
        countRow++;
        
        if (sideSize - countRow == 0)
        {
            isLeftSideToFill = false;
            isTopSideToFill = true;
            sideSize--;
            countRow = sideSize - round;
            countColumn = sideSize - round;
            round++;
        }
    }

}

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        if (matrix[i, j] < 10) Console.Write($"0{matrix[i, j]} ");
        else Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

bool isEnd(int currentDigit, int size)
{
    return currentDigit == size * size + 1;
}