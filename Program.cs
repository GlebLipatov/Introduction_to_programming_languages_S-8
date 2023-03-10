Start();

const string FIFTYFOUR = "54";
const string FIFTYSIX = "56";
const string FIFTYEIGHT = "58";
const string SIXTY = "60";
const string SIXTYTWO = "62";
const string QUIT = "q";

void Start()
{
    Console.WriteLine("Введите номер задачи (54, 56, 58, 60, 62) или 'q' что бы выйти: ");

    switch (isValidInputMenu(Console.ReadLine()))
    {
        case FIFTYFOUR:
            //Task54(true);
            Start();
            break;
        case FIFTYSIX:
            Task56(); 
            Start();
            break;
        case FIFTYEIGHT:
            Task58();
            Start();
            break;
        case SIXTY:
            Task60();
            Start();
            break;
        case SIXTYTWO:
            Task62();
            Start();
            break;
        case QUIT:
            Console.WriteLine("Пока!");
            break;
    }
}

string isValidInputMenu(string userInput)
{
    userInput = userInput.ToLower();

    if (userInput == FIFTYFOUR
     || userInput == FIFTYSIX
     || userInput == FIFTYEIGHT
     || userInput == SIXTY
     || userInput == SIXTYTWO
     || userInput == QUIT)
    {
        return userInput;
    }
    else
    {
        Console.WriteLine("Введите номер задачи (54, 56, 58, 60, 62) или 'q' что бы выйти:");
        return isValidInputMenu(Console.ReadLine());
    }
}

// ============= Задачи ============= \\

/// <summary>/// 
/// Задача 56. Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
/// </summary>
void Task56()
{
    Console.WriteLine("Задача 56. Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.\n");
    const int ROWSIZE = 4;
    const int COLUMNSIZE = 3;
    const int MINVALUE = 0;
    const int MAXVALUE = 10;

    int[,] matrix = FillMatrix2d(ROWSIZE, COLUMNSIZE, MINVALUE, MAXVALUE);
    int result = int.MaxValue;
    int resultRow = 0;
    int temp;

    for (int i = 0; i < ROWSIZE; i++)
    {
        temp = 0;
        for (int j = 0; j < COLUMNSIZE; j++)
        {
            temp += matrix[i, j];
            Console.Write($"{matrix[i, j]} ");
        }

        if (result > temp)
        {
            result = temp;
            resultRow = i;
        }

        Console.WriteLine("");
    }

    Console.WriteLine($"\nВ прямоугольном массиве строкой с наименьшей суммой элементов является {resultRow + 1}, где сумма = {result}\n");
}

/// <summary>
/// Задача 58. Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
/// </summary>
void Task58()
{
    Console.WriteLine("Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.\n");

    const int TWO = 2;
    const int MINVALUE = 0;
    const int MAXVALUE = 10;
    int result;

    int[,] firstMatrix = FillMatrix2d(TWO, TWO, MINVALUE, MAXVALUE);
    int[,] secondMatrix = FillMatrix2d(TWO, TWO, MINVALUE, MAXVALUE);
    int[,] resultsMatrix = new int[TWO, TWO];

    for (int i = 0; i < TWO; i++)
    {
        for (int j = 0; j < TWO; j++)
        {
            result = firstMatrix[i,j] * secondMatrix[i,j];
            resultsMatrix[i,j] = result;

            if (result < 10) Console.Write($"0{result} ");
            else Console.Write($"{result} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

/// <summary>
/// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.Массив размером 2 x 2 x 2
/// </summary>
void Task60()
{
    Console.WriteLine("Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.Массив размером 2 x 2 x 2\n");
    
    const int TWO = 2;
    int value;

    int[,,] matrix3d = new int[TWO, TWO, TWO];

    for (int i = 0; i < TWO; i++)
    {
        for (int j = 0; j < TWO; j++)
        {
            for (int k = 0; k < TWO; k++)
            {
                value = new Random().Next(10, 100);
                matrix3d[i, j, k] = value;
                Console.Write($"{value}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

/// <summary>
/// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
/// </summary>
void Task62()
{
    // Хотел сделать что бы метод выдавал спиральную матрицу не только 4х4, но и бОльших размеров, пока не успел(((

    Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");

    const int SIZE = 4;
    int sideSize = SIZE - 1; // Переменная для индексации массивов.
    int[,] matrix = new int[SIZE, SIZE];
    int countRow = sideSize;
    int countColumn = sideSize;
    int currentDigit = 1; // Генератор чисел в матрицу.
    int row = sideSize - countColumn;
    int column = sideSize - countColumn;
    int lap = 0;

    // Логические переменные ветвлений для заполнения конкретных сторон матрицы.
    bool isTopSideToFill = true;
    bool isRightSideToFill = false;
    bool isBottomSideToFill = false;
    bool isLeftSideToFill = false;

    while (!isEnd(currentDigit, SIZE))
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

            if (sideSize - countColumn == lap)
            {
                isBottomSideToFill = false;
                isLeftSideToFill = true;
            }
        }
        else if (isLeftSideToFill)
        {
            matrix[row, column] = currentDigit++;
            countRow++;

            if (sideSize - countRow == lap)
            {
                isLeftSideToFill = false;
                isTopSideToFill = true;
                sideSize--;
                countRow = sideSize - 1;
                countColumn = sideSize - 1;
                lap++;
            }
        }
    }

    // Печатаем заполненную матрицу.
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            if (matrix[i, j] < 10) Console.Write($"0{matrix[i, j]} ");
            else Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Проверка выхода из цикла.
    /// </summary>
    /// <param name="currentDigit">Счетчик который проверяем.</param>
    /// <param name="size">Размер квадратной матрицы.</param>
    /// <returns>Истину если счетчик достигает квадрата размера матрицы.</returns>
    bool isEnd(int currentDigit, int size)
    {
        return currentDigit == SIZE * SIZE + 1;
    }
}

/// <summary>
/// Заполняет двумерый массив.
/// </summary>
/// <param name="rowSize">Размер внешнего массива.</param>
/// <param name="columnSize">Размер внутреннего массива.</param>
/// <param name="minValue">Минимальное рандомное значение.</param>
/// <param name="maxValue">Максимальное рандомное значение.</param>
/// <returns></returns>
int[,] FillMatrix2d(int rowSize, int columnSize, int minValue, int maxValue)
{
    int[,] matrix = new int[rowSize, columnSize];
    Random rnd = new Random();

    for (int i = 0; i < rowSize; i++)
    {
        for (int j = 0; j < columnSize; j++)
        {
            matrix[i,j] = rnd.Next(minValue, maxValue); 
        }
    }

    return matrix;
}